using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.Data
{
    public class SeriesModel
    {
        public SeriesModel() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Categories { get; set; }
        public string Overview { get; set; }
        public SeriesModel(
            int id, 
            string title,
            string logo,
            string categories,
            string overview) 
        {
            this.Id = id;
            this.Title = title;
            this.Logo = logo;
            this.Categories = categories;
            this.Overview = overview;
        }
    }
}
