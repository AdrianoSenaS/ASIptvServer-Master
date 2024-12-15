using ASIptvServer.M3U;
using ASIptvServer.Naming.Renamber;
using ASIptvServer.Naming;
using ASIptvServer.Models;
using ASIptvServer.Api.Interfaces;

namespace ASIptvServer.Api.Models
{

    public class M3uService : IM3uService
    {
        private readonly IMovieService _movieService;
        private readonly ISeriesService _seriesService;
        private readonly ITvService _tvService;

        public M3uService(IMovieService movieService, ISeriesService seriesService, ITvService tvService)
        {
            _movieService = movieService;
            _seriesService = seriesService;
            _tvService = tvService;
        }

        public void UpdateM3uPath(string pathM3u)
        {
            M3UPath m3UPath = new M3UPath(pathM3u);
            var dt = M3UList.M3uPath(m3UPath);
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
                        movie.Categories = item.Categories;
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
        public  void UpdateM3uUrl(string url)
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
                        movie.Categories = item.Categories;
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
    }
}
