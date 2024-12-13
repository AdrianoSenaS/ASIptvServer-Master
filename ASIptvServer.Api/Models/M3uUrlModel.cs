using ASIptvServer.M3U;
using ASIptvServer.Naming.Renamber;
using ASIptvServer.Naming;
using ASIptvServer.Data.Data;
using ASIptvServer.Data;

namespace ASIptvServer.Api.Models
{
    public class M3uUrlModel
    {

        public static void UpdateM3uPath(string pathM3u)
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
                            Console.WriteLine("Resultado: " + item.Name);
                        }
                        movie.Logo = item.Logo;
                        movie.Overview = string.Empty;
                        movie.Categories = item.Categories;
                        movie.Url = item.Url;
                        movie.Date = result.Year;
                        DbMovies.SetMovies(movie);
                        category.Category = item.Categories;
                        DbMovies.SetCategoryMovies(category);
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
                        DbTV.SetTv(tv);
                        categories.Category = item.Categories;
                        DbTV.SetCategoryTv(categories);
                        Console.WriteLine("Resultado: " + item.Name);
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }
        public static void UpdateM3uUrl(string url)
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
                            Console.WriteLine("Resultado: " + item.Name);
                        }
                        movie.Logo = item.Logo;
                        movie.Overview = string.Empty;
                        movie.Categories = item.Categories;
                        movie.Url = item.Url;
                        movie.Date = result.Year;
                        DbMovies.SetMovies(movie);
                        category.Category = item.Categories;
                        DbMovies.SetCategoryMovies(category);

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
                        DbTV.SetTv(tv);
                        categories.Category = item.Categories;
                        DbTV.SetCategoryTv(categories);
                        Console.WriteLine("Resultado: " + item.Name);
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
