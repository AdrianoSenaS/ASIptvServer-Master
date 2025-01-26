namespace ASIptvServer.M3U.Model
{
    public class M3uModel
    {
        public M3uModel() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Categories { get; set; }
        public string Url { get; set; }
        public bool Movies { get; set; }
        public bool Serie { get; set; }
        public bool Tv { get; set; }
        public bool Radio { get; set; }
        public M3uModel(int id, string name,
            string logo,
            string categories,
            string url,
            bool film,
            bool serie,
            bool tv,
            bool radio)
        {
            Id = id;
            Name = name;
            Logo = logo;
            Categories = categories;
            Url = url;
            Movies = film;
            Serie = serie;
            Tv = tv;
            Radio = radio;
        }

    }
}
