namespace ASIptvServer.M3U.Model
{
    public class M3uPathModel
    {
        public M3uPathModel() { }
        public string Path { get; set; }
        public M3uPathModel(string path)
        {
            Path = path;
        }
    }
}
