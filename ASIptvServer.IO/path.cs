using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.IO
{
    public class path
    {
        public path() { }
        public string Local {  get; set; }
        public path( string local) 
        {
            this.Local = local;
        }

    }
}
