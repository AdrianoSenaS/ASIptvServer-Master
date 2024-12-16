using ASIptvServer.M3U;
using ASIptvServer.Naming.Renamber;
using ASIptvServer.Naming;
using ASIptvServer.Api.Models;
using ASIptvServer.Api.Interfaces;
using ASIptvServer.Api.Services.Movies;
using ASIptvServer.Api.Services.Tv;

namespace ASIptvServer.Api.Services.M3u
{

    public class M3uService : IM3uService
    {
        private readonly ISeriesService _seriesService;
        private readonly ImoviesSevices _imoviesSevices;
        private readonly ITvServices _tvServices;

        public M3uService(ISeriesService seriesService,
        ITvService tvService,
        ImoviesSevices imoviesSevices, 
        ITvServices tvServices)
        {
            _seriesService = seriesService;
            _imoviesSevices = imoviesSevices;
            _tvServices = tvServices;
        }
        public void UpdateM3uPath(string pathM3u)
        {
            int Count = CountM3u(pathM3u);
            int id = 0;
            M3UPath m3UPath = new M3UPath(pathM3u);
            var dt = M3UList.M3uPath(m3UPath);
            foreach (var item in dt.Result)
            {
                id++;
                item.Id = id;
                NamingPath naming = new NamingPath(item.Name);
                var result = Renamber.SetNaming(naming);
                if (!item.Tv && !item.Serie && !item.Radio)
                {
                    //Chamar função para filmes
                    _imoviesSevices.Movie(item,result);
                }
                if (item.Tv)
                {
                    // chamar função tv
                    _tvServices.TV(item);
                }
                if (result.IsSerie)
                {
                    //chamr função para séries
                }
            }
        }
        public void UpdateM3uUrl(string url)
        {

            M3Uurl m3Uurl = new M3Uurl(url);
            var dt = M3UList.M3Uurl(m3Uurl);
            foreach (var item in dt.Result)
            {
                try
                {
                    NamingPath namingPath = new NamingPath(item.Name);
                    var result = Renamber.SetNaming(namingPath);
                    if (result.IsSerie)
                    {
                        SeriesModel series = new SeriesModel();
                        CategoriesModel categories = new CategoriesModel();
                        series.Id = item.Id;
                        series.Title = result.Name;
                        series.Logo = item.Logo;
                        series.Categories = item.Categories;
                        series.Overview = string.Empty;
                        _seriesService.SetSeries(series);
                        categories.Category = item.Categories;
                        _seriesService.SetCategorySeries(categories);
                        Console.WriteLine("Adicionando: " + result.Name);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private int CountM3u(string pathM3u)
        {
            int id = 0;
            M3UPath m3UPath = new M3UPath(pathM3u);
            var dt = M3UList.M3uPath(m3UPath);
            foreach (var item in dt.Result)
            {
                id++;
                item.Id = id;
            }
            return id;
        }
    }
}
