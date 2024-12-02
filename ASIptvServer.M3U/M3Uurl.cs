using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.M3U
{
    public class M3Uurl
    {
        public M3Uurl() { }
        public string Url { get; set; }
        public M3Uurl(string url)
        {
            Url = url;
        }
    }
}
