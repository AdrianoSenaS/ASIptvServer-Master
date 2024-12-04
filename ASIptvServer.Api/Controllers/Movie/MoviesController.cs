using Microsoft.AspNetCore.Mvc;
using ASIptvServer.Data.Data;
using ASIptvServer.Data;

namespace ASIptvServer.Api.Controllers.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<MovieModel>> GetMovies()
        {
            return DbMovies.GetMovies();
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MovieModel>> GetMoviesId(int id)
        {
            return DbMovies.GetMoviesId(id);
        }
        [HttpGet("Categories")]
        public ActionResult<IEnumerable<Categories>> GetMoviesCategories()
        {
            return DbMovies.GetCategoryMovies();
        }
        [HttpGet("Categories/{Categories}")]
        public ActionResult<IEnumerable<MovieModel>> GetMoviesCategoriesId(string Categories)
        {
            return DbMovies.GetCategoryMoviesId(Categories);
        }

    }
}
