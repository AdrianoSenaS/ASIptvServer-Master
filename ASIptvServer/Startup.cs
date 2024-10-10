using ASIptvServer.Data;
using ASIptvServer.Models;

namespace ASIptvServer
{
    public class Startup
    {
        public static void Start()
        {
            
            IOpath.CreatePath();
            DbData.CreateDatabase();

        }
    }
}
