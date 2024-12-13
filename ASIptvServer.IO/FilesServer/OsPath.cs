using ASIptvServer.Configuration;

namespace ASIptvServer.IO.FilesServer
{
    public class OsPath
    {
        public static void CreatePath()
        {
            path path = new path(VerificationOs.Verification().PathRot);
            Folder.CreateFolder(path);
            path = new path(VerificationOs.Verification().PathData);
            Folder.CreateFolder(path);
            path = new path(VerificationOs.Verification().PathTemp);
            Folder.CreateFolder(path);
            path = new path(VerificationOs.Verification().PathTempData);
            Folder.CreateFolder(path);
        }
    }
}
