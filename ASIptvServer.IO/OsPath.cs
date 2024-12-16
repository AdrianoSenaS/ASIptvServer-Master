using ASIptvServer.System.Configuration;
using ASIptvServer.IO.FilesServer;
namespace ASIptvServer.IO
{
    public interface IOsPath
    {
        void CreatePath();
    }
    public class OsPath : IOsPath
    {
        private readonly IVerification _verification;

        public OsPath(IVerification verification)
        {
            _verification = verification;
        }
        public  void CreatePath()
        {
            path path = new path(_verification.Verification().PathRot);
            Folder.CreateFolder(path);
            path = new path(_verification.Verification().PathData);
            Folder.CreateFolder(path);
            path = new path(_verification.Verification().PathTemp);
            Folder.CreateFolder(path);
            path = new path(_verification.Verification().PathTempData);
            Folder.CreateFolder(path);
        }
    }
}
