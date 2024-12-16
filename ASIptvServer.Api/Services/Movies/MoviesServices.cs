using ASIptvServer.System.Configuration;
using ASIptvServer.TMDB;
using ASIptvServer.Api.Models;
using ASIptvServer.Api.Interfaces;
using Microsoft.Extensions.Logging;
namespace ASIptvServer.Api.Services.Movies
{
    public interface ImoviesSevices
    {
        void Movie(M3U.M3U m3U, Naming.Naming naming);
    }
    public class MoviesServices : ImoviesSevices
    {
        public readonly ITMDBMovie _itmdbMovie;
        private readonly IMovieService _movieService;
        private readonly IVerification _verification;
        public MoviesServices(ITMDBMovie itmdbMovie, IMovieService movieService, IVerification verification)
        {
            _itmdbMovie = itmdbMovie;
            _movieService = movieService;
            _verification = verification;
        }
        public void Movie(M3U.M3U m3U, Naming.Naming naming)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddProvider(new FileLoggerProvider(_verification.Verification().PathTemp + "Movie.log"));
            });
            ILogger logger = loggerFactory.CreateLogger("Filmes M3U");
            string imagTdbm = "https://image.tmdb.org/t/p/w500";
            MovieModel movie = new MovieModel();
            CategoriesModel categories = new CategoriesModel();
            var result = _itmdbMovie.GetMovie(naming.Name, naming.Year);
            if (result.Title != null)
            {
                
                logger.LogInformation("Adicionando  Filme: " +result.Title);
                movie.Title = result.Title;
                movie.Logo = imagTdbm + result.poster_path;
            }
            else
            {
                logger.LogWarning("Adicionado Filme sem consulta no TMDB: "+m3U.Name);   
                movie.Title = m3U.Name;
                movie.Logo = m3U.Logo;
            }
            if (m3U.Categories != null)
            {
                movie.Categories = m3U.Categories;
                categories.Category = m3U.Categories;
            }
            else
            {
                logger.LogWarning("Cateoria não encontrada: " + m3U.Categories);
                logger.LogInformation("Adicionando Categoria: Sem categoria");
                movie.Categories = "Sem categoria";
                categories.Category = "Sem categoria";
            }
            movie.Overview = result.Overview;
            movie.Url = m3U.Url;
            movie.Date = naming.Year;
            _movieService.SetMovies(movie);
            _movieService.SetCategoryMovies(categories);
            logger.LogInformation("Fime adicionado com sucesso! "+ movie.Title);
        }
    }
}
