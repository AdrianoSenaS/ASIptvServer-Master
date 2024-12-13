using ASIptvServer.Configuration;
namespace ASIptvServer.Data.Database
{
    public class DbPath
    {
        public static string Local = $"Data Source={VerificationOs.Verification().PathData}DATABASE.db;Version=3;";

    }
}
