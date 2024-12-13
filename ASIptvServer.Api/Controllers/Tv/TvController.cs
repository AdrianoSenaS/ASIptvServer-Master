using Microsoft.AspNetCore.Mvc;
using ASIptvServer.Data.Data;
using ASIptvServer.Data;

namespace ASIptvServer.Api.Controllers.Tv
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvController
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<TvModel>> GetTv()
        {
            return DbTV.GetTv(); ;
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TvModel>> GetTvId(int id)
        {
            return DbTV.GetTvId(id);
        }
        // POST api/<ValuesController>
        [HttpGet("Categories")]
        public ActionResult<IEnumerable<CategoriesModel>> GetCategories()
        {
            return DbTV.GetCategoryTv();
        }
        // PUT api/<ValuesController>/5
        [HttpGet("Categories/{Categories}")]
        public ActionResult<IEnumerable<TvModel>> GetCategoriesId(string Categories)
        {
            return DbTV.GetCategoryTvId(Categories);
        }
    }
}
