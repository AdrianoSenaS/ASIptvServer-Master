
namespace ASIptvServer.Models
{
    public class TvModel
    {
        public TvModel() { }   
        public int Id { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Categories { get; set; }
        public string Url { get; set; }
        public TvModel(int id, 
            string title, 
            string logo, string 
            categories, 
            string url) 
        {
            this.Id = id;
            this.Title = title;
            this.Logo = logo;
            this.Categories = categories;
            this.Url = url;
        }
    }
}
