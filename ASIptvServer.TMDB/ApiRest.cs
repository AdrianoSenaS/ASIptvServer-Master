using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.TMDB
{
    public  class ApiRest
    {
        public RestClient restClient {  get; set; }
        public RestRequest restRequest { get; set; }
    }
}
