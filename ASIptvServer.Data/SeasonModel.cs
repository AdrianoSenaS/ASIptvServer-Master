using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.Data
{
    public class SeasonModel
    {
        public SeasonModel() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Season { get; set; }
        public SeasonModel(
            int id,
            string title,
            string season)
        {
            Id = id;
            Title = title;
            Season = season;
        }
    }
}
