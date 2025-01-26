namespace ASIptvServer.M3U.Model
{
    public class M3uUrlModel
    {
        public M3uUrlModel() { }
        public string Url { get; set; }
        public M3uUrlModel(string url)
        {
            Url = url;
        }
    }
}
