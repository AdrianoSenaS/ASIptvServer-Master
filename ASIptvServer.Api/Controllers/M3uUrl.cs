using ASIptvServer.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASIptvServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class M3uUrl
    {
        // POST api/<ValuesController>
        [HttpPost]
        public async void Post( string url)
        {

            M3uUrlModel.UpdateM3u(url);

        }
    }
}
