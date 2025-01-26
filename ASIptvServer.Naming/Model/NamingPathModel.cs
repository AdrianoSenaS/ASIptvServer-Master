namespace ASIptvServer.Naming.Model
{
    public class NamingPathModel
    {
        public NamingPathModel() { }
        public string Path { get; set; }
        public NamingPathModel(string path)
        {
            Path = path;
        }

    }
}
