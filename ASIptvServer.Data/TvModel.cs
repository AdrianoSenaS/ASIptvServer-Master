using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.Data
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
            Id = id;
            Title = title;
            Logo = logo;
            Categories = categories;
            Url = url;
        }
    }
}
