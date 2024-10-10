using ASIptvServer.IO.FilesServer;
using ASIptvServer.IO;
using ASIptvServer.M3U;
using ASIptvServer.Naming.Renamber;
using ASIptvServer.Naming;
using ASIptvServer.Data.Data;
using ASIptvServer.Data;

namespace ASIptvServer.Api.Models
{
    public class M3uUrlModel
    {
        public static string pathM3u = @"C:\temp\ASIptvServer\lista.m3u";

        public static void UpdateM3uPath()
        {
            M3UPath m3UPath = new M3UPath(pathM3u);
            var dt = M3UList.M3uPath(m3UPath);
            foreach (var item in dt)
            {
                Console.WriteLine("Nome: " + item.Name);
                Console.WriteLine("Logo: " + item.Logo);
                Console.WriteLine("Categoria: " + item.Categories);
                Console.WriteLine("Url: " + item.Url);
                try
                {
                    NamingPath namingPath = new NamingPath(item.Name);
                    var result = Renamber.SetNaming(namingPath);
                    if (!item.Tv && !item.Serie && !item.Radio)
                    {
                        MovieModel movie = new MovieModel();
                        CategoryMovieModel category = new CategoryMovieModel();
                        movie.Id = item.Id;
                        movie.Title = result.Name;
                        movie.Logo = item.Logo;
                        movie.Overview = string.Empty;
                        movie.Categories = item.Categories;
                        movie.Url = item.Url;
                        movie.Date = result.Year;
                        DbMovies.SetMovies(movie);
                        category.Category = item.Categories;
                        DbMovies.SetCategoryMovies(category);

                    }
                }
                catch (Exception)
                {
                    if (!item.Tv && !item.Serie && !item.Radio)
                    {
                        MovieModel movie = new MovieModel();
                        CategoryMovieModel category = new CategoryMovieModel();
                        movie.Id = item.Id;
                        movie.Title = item.Name;
                        movie.Logo = item.Logo;
                        movie.Overview = string.Empty;
                        movie.Categories = item.Categories;
                        movie.Url = item.Url;
                        movie.Date = string.Empty;
                        DbMovies.SetMovies(movie);
                        category.Category = item.Categories;
                        DbMovies.SetCategoryMovies(category);

                    }
                }
            }
        }
        public static void UpdateM3uUrl(string url)
        {
            M3Uurl m3Uurl = new M3Uurl(url);
            var dt =  M3UList.M3Uurl(m3Uurl);
            foreach (var item in dt.Result)
            {
                Console.WriteLine("Nome: " + item.Name);
                Console.WriteLine("Logo: " + item.Logo);
                Console.WriteLine("Categoria: " + item.Categories);
                Console.WriteLine("Url: " + item.Url);
                try
                {
                    NamingPath namingPath = new NamingPath(item.Name);
                    var result = Renamber.SetNaming(namingPath);
                    if (!item.Tv && !item.Serie && !item.Radio)
                    {
                        MovieModel movie = new MovieModel();
                        CategoryMovieModel category = new CategoryMovieModel();
                        movie.Id = item.Id;
                        movie.Title = result.Name;
                        movie.Logo = item.Logo;
                        movie.Overview = string.Empty;
                        movie.Categories = item.Categories;
                        movie.Url = item.Url;
                        movie.Date = result.Year;
                        DbMovies.SetMovies(movie);
                        category.Category = item.Categories;
                        DbMovies.SetCategoryMovies(category);

                    }
                }
                catch (Exception)
                {
                    if (!item.Tv && !item.Serie && !item.Radio)
                    {
                        MovieModel movie = new MovieModel();
                        CategoryMovieModel category = new CategoryMovieModel();
                        movie.Id = item.Id;
                        movie.Title = item.Name;
                        movie.Logo = item.Logo;
                        movie.Overview = string.Empty;
                        movie.Categories = item.Categories;
                        movie.Url = item.Url;
                        movie.Date = string.Empty;
                        DbMovies.SetMovies(movie);
                        category.Category = item.Categories;
                        DbMovies.SetCategoryMovies(category);

                    }
                }
                
            }
        }
    }
}
