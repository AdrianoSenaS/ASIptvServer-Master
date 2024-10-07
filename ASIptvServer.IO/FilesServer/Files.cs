namespace ASIptvServer.IO.FilesServer
{
    public class Files
    {
        public static void CreateFile(path path, string value)
        {
            try
            {
                File.AppendAllText(path.Local, value);
            }
            catch (Exception)
            {
            }
        }
    }
}
