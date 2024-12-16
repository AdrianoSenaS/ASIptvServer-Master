using ASIptvServer.M3U;
using ASIptvServer.Naming.Renamber;
using ASIptvServer.Naming;
using ASIptvServer.Api.Models;
using ASIptvServer.Api.Interfaces;
using ASIptvServer.Api.Services.Movies;

namespace ASIptvServer.Api.Services.M3u
{

    public class M3uService : IM3uService
    {
        private readonly IMovieService _movieService;
        private readonly ISeriesService _seriesService;
        private readonly ITvService _tvService;
        private readonly ImoviesSevices _imoviesSevices;

        public M3uService(IMovieService movieService,
        ISeriesService seriesService,
        ITvService tvService,
        ImoviesSevices imoviesSevices)
        {
            _movieService = movieService;
            _seriesService = seriesService;
            _tvService = tvService;
            _imoviesSevices = imoviesSevices;
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
                    if (!item.Tv && !item.Serie && !item.Radio)
                    {
                        MovieModel movie = new MovieModel();
                        CategoriesModel category = new CategoriesModel();
                        movie.Id = item.Id;
                        if (result.Name != null || result.Name != string.Empty)
                        {
                            movie.Title = result.Name;
                            Console.WriteLine("Resultado: " + result.Name);
                        }
                        else
                        {
                            movie.Title = item.Name;
                        }
                        movie.Logo = item.Logo;
                        movie.Overview = string.Empty;
                        if (item.Categories != null)
                        {
                            movie.Categories = item.Categories;
                        }
                        else
                        {
                            movie.Categories = string.Empty;
                        }
                        movie.Url = item.Url;
                        movie.Date = result.Year;
                        _movieService.SetMovies(movie);
                        category.Category = item.Categories;
                        _movieService.SetCategoryMovies(category);

                    }
                    if (item.Tv)
                    {
                        TvModel tv = new TvModel();
                        CategoriesModel categories = new CategoriesModel();
                        tv.Id = item.Id;
                        tv.Title = item.Name;
                        tv.Logo = item.Logo;
                        tv.Categories = item.Categories;
                        tv.Url = item.Url;
                        _tvService.SetTv(tv);
                        categories.Category = item.Categories;
                        _tvService.SetCategoryTv(categories);
                        Console.WriteLine("Resultado: " + item.Name);
                    }
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
