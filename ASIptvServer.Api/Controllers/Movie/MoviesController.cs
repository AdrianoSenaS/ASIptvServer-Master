using Microsoft.AspNetCore.Mvc;
using ASIptvServer.Models;
using ASIptvServer.Api.Interfaces;

namespace ASIptvServer.Api.Controllers.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<MovieModel>> GetMovies()
        {
            var movies= _movieService.GetMovies();
            return movies;
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MovieModel>> GetMoviesId(int id)
        {
            var movies = _movieService.GetMoviesId(id);
            return movies;
        }
        [HttpGet("Categories")]
        public ActionResult<IEnumerable<CategoriesModel>> GetMoviesCategories()
        {
            var categories = _movieService.GetCategoryMovies();
            return categories;
        }
        [HttpGet("Categories/{Categories}")]
        public ActionResult<IEnumerable<MovieModel>> GetMoviesCategoriesId(string Categories)
        {
            var categoriesId = _movieService.GetCategoryMoviesId(Categories);
            return categoriesId;
        }
    }
}
