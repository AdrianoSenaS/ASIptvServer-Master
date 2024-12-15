using ASIptvServer.Configuration;
using ASIptvServer.Api.Interfaces;
namespace ASIptvServer.Data.Database
{
    

    public class DbPath : IDbPath
    {
        private readonly IVerification _verification;

        public DbPath(IVerification verification)
        {
            _verification = verification;
        }
        public string Local()
        {
            return $"Data Source={_verification.Verification().PathData}DATABASE.db;Version=3;";
        }
    }
}
