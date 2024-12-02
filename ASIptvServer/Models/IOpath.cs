using ASIptvServer.IO;
using ASIptvServer.IO.FilesServer;
namespace ASIptvServer.Models
{
    public class IOpath
    {

        public static string PathRoot = @"C:\ASIptvServer\";
        public static string PathData = @"C:\ASIptvServer\Database\";
        public static string PathTemp = @"C:\temp\";
        public static string PathTempData = @"C:\temp\ASIptvServer\";


        public static void CreatePath()
        {
            path path = new path(PathRoot);
            Folder.CreateFolder(path);
            path = new path(PathData);
            Folder.CreateFolder(path);
            path = new path(PathTemp);
            Folder.CreateFolder(path);
            path = new path(PathTempData);
            Folder.CreateFolder(path);
        }

      
    }
}
