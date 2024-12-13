using ASIptvServer.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASIptvServer.Api.Controllers.Series
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController
    {
        [HttpGet]
        public ActionResult<IEnumerable<SeriesModel>> GetSeries() 
        {
            List<SeriesModel> series = new List<SeriesModel>();

            return series;
        }
    }
}
