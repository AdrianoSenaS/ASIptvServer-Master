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
        public MoviesServices(ITMDBMovie itmdbMovie,
            IMovieService movieService,
            IVerification verification)
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
            string ImageTMDB = "https://image.tmdb.org/t/p/w500";
            MovieModel movie = new MovieModel();
            CategoriesModel categories = new CategoriesModel();
            var result = Search(naming.Name, naming.Year);
            if (result.Title!= string.Empty)
            {
                movie.Title = result.Title;
                movie.Logo = ImageTMDB+ result.poster_path;
                movie.Overview = result.Overview;
            }
            else
            {
                result = Search(naming.Name, string.Empty);
                if (result.Title != string.Empty)
                {
                    movie.Title = result.Title;
                    movie.Logo = ImageTMDB + result.poster_path;
                    movie.Overview = result.Overview;
                }
                else
                {
                    movie.Title = naming.Name;
                    movie.Logo = m3U.Logo;
                    movie.Overview = string.Empty;
                    logger.LogWarning("Adicionando  Filme sem consulta ao TMDB: " + movie.Title);
                }
            }
            if (m3U.Categories != null)
            {
                movie.Categories = m3U.Categories;
                categories.Category = m3U.Categories;
            }
            else
            {
                logger.LogInformation("Adicionando Categoria: Sem categoria");
                movie.Categories = "Sem categoria";
                categories.Category = "Sem categoria";
            }
            movie.Id = m3U.Id;
            movie.Url = m3U.Url;
            movie.Date = naming.Year;
            _movieService.SetMovies(movie);
            _movieService.SetCategoryMovies(categories);
            logger.LogInformation("Adicionando  Filme: " + movie.Title);
        }
        private MovieTMDBModel Search(string name, string year)
        {
            MovieTMDBModel movie = new MovieTMDBModel();
            var movieTMDB = _itmdbMovie.GetMovie(name, year);
            if (movieTMDB != null) 
            {
                movie = movieTMDB;
            }
            if (movieTMDB.original_title == name)
            {
               movie.Title = movieTMDB.original_title;
            }
            if (movieTMDB.Title == name)
            {
                movie.Title = name;
            }
            else
            {
                movie.Title = string.Empty;
            }
            return movie;
        }
    }
}
