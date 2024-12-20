using ASIptvServer.Api.Models;

namespace ASIptvServer.Api.Interfaces
{
    public interface IMovieService
    {
        List<MovieModel> GetMovies();
        MovieModel GetMoviesId(int id);
        void SetMovies(MovieModel movie);
        List<CategoriesModel> GetCategoryMovies();
        List<MovieModel> GetCategoryMoviesId(string category);
        void SetCategoryMovies(CategoriesModel category);
    }
}
