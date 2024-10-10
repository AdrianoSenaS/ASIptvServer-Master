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
    public class MoviesController
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // GET api/<ValuesController>/5
        [HttpGet("{Categories}")]
        public string Get(string Categories)
        {
            return "value";
        }

    }
}
