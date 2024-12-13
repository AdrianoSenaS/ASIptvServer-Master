using ASIptvServer.Data.Database;
using ASIptvServer.IO.FilesServer;

namespace ASIptvServer
{
    public class Startup
    {
        public static void Start()
        {
            OsPath.CreatePath();
            DbData.CreateDatabase();
        }
    }
}
