namespace ASIptvServer.Data
{
    public class MovieModel
    {
        public MovieModel() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Categories { get; set; }
        public string Overview { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public MovieModel(int id, 
            string title, 
            string logo, 
            string categories, 
            string overview, 
            string url, 
            string date)
        {
            this.Id = id;
            this.Title = title;
            this.Logo = logo;
            this.Categories = categories;
            this.Overview = overview;
            this.Url = url;
            this.Date = date;
        }
    }
}
