namespace ASIptvServer.Models
{
    public class EpisodeModel
    {
        public EpisodeModel() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Logo {  get; set; }
        public string Categories { get; set; }
        public string Overview { get; set; }
        public string Season { get; set; }
        public string Episode { get; set; }
        public string Url { get; set; }
        public EpisodeModel(
            int id, 
            string title, 
            string logo,  
            string categories, 
            string overview,
            string season, 
            string episode, 
            string url)
        {
            this.Id = id;
            this.Title = title;
            this.Logo = logo;
            this.Categories = categories;
            this.Overview = overview;
            this.Season = season;
            this.Episode = episode;
            this.Url = url;
        }
    }
}
