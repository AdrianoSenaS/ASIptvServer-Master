namespace ASIptvServer.M3U
{
    public class M3U
    {
        public M3U() { }
        public int Id   { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Categories { get; set; }
        public string Url   { get; set; }
        public bool Films { get; set; }
        public bool Serie { get; set; }
        public bool Tv { get; set; }
        public M3U(int id, string name, string logo, string categories, string url, bool film, bool serie, bool tv) 
        {
            this.Id = id;
            this.Name = name;
            this.Logo = logo;
            this.Categories = categories;
            this.Url = url;
            this.Films = film;
            this.Serie = serie;
            this.Tv = tv;
        }

    }
}
