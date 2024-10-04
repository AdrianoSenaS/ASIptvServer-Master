using System.IO;

namespace ASIptvServer.IO.FilesServer
{
    public class Folder
    {
        public static void CreateFolder(path path)
        {
            try
            {
                if (!Directory.Exists(path.Local))
                {
                    Directory.CreateDirectory(path.Local);
                }
            }catch (Exception)
            {
            }
        } 
    }
}
