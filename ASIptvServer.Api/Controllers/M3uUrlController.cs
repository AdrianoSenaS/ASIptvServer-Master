using ASIptvServer.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASIptvServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class M3uUrlController
    {
        
        [HttpGet]
        public void Get()
        {
            M3uUrlModel.UpdateM3uPath();
        }
        [HttpPost]
        public void Post(string url) 
        {
            M3uUrlModel.UpdateM3uUrl(url);
        }
    }
}
