using Microsoft.AspNetCore.Mvc;
using ASIptvServer.Api.Models;
using ASIptvServer.Api.Interfaces;

namespace ASIptvServer.Api.Controllers.Tv
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvController
    {
        private readonly ITvService _tvService;

        public TvController(ITvService tvService)
        {
            _tvService = tvService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TvModel>> GetTv()
        {
            return _tvService.GetTv(); ;
        }

        [HttpGet("{id}")]
        public ActionResult<TvModel> GetTvId(int id)
        {
            return _tvService.GetTvId(id);
        }

        [HttpGet("Categories")]
        public ActionResult<IEnumerable<CategoriesModel>> GetCategories()
        {
            return _tvService.GetCategoryTv();
        }

        [HttpGet("Categories/{Categories}")]
        public ActionResult<IEnumerable<TvModel>> GetCategoriesId(string Categories)
        {
            return _tvService.GetCategoryTvId(Categories);
        }
    }
}
