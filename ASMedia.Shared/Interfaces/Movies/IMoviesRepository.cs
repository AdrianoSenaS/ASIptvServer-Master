using ASMedia.Shared.Model.Movies;

namespace ASMedia.Shared.Interfaces.Movies
{
    public interface IMoviesRepository
    {
        public Task<string> AddMovie(MoviesResponse movies);
        public Task<List<MoviesResponse>> GetMovies();
        public Task<MoviesResponse> GetMovieId(int Id);
        public Task<string> UpdateMovie(MoviesResponse movies);
        public Task<string> DeleteMovie(int Id);
    }
}
