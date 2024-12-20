using ASIptvServer.Api.Models;
using Microsoft.AspNetCore.Mvc;
using ASIptvServer.Api.Interfaces;

namespace ASIptvServer.Api.Controllers.Series
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController
    {
        private readonly ISeriesService _seriesService;
        public SeriesController(ISeriesService seriesService) 
        {
            _seriesService = seriesService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SeriesModel>> GetSeries() 
        {
            List<SeriesModel> series = _seriesService.GetSeries();
            return series;
        }
        [HttpGet("{id}")]
        public ActionResult<SeriesModel> GetSeriesId(int id)
        {
            SeriesModel series = _seriesService.GetDbSeriesId(id);
            return series;
        }
        [HttpGet("Categories")]
        public ActionResult<IEnumerable<CategoriesModel>> GetCategoriesSeries()
        {
            List<CategoriesModel> categories = _seriesService.GetCateoriesSeries();
            return categories;
        }
        [HttpGet("Categories/{Categories}")]
        public ActionResult<IEnumerable<SeriesModel>> GetCateoriesSeriesId(string Categories)
        {
            List<SeriesModel> series = _seriesService.GetCategoriesSeriesId(Categories);
            return series;
        }
    }
}
