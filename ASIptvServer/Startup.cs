using ASIptvServer.Data.Database;
using ASIptvServer.IO.FilesServer;
using ASIptvServer.Api.Interfaces;

namespace ASIptvServer
{
    public class Startup
    {
        private readonly IDatabase _database;
        public Startup(IDatabase database)
        {
            _database = database;
        }

        public void Start()
        {
            OsPath.CreatePath();
            _database.CreateDatabase();
        }
    }
}
