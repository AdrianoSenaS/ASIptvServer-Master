using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesCast
    { 
        // GET api/<ValuesController>/5
        [HttpGet("{Movie}")]
        public string Get(string Movie)
        {
            return "value";
        }
    }
}
