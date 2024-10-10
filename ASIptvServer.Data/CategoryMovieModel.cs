using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.Data
{
   public class CategoryMovieModel
    {
        public CategoryMovieModel() { }
        public int Id { get; set; }
        public string Category { get; set; }
        public CategoryMovieModel(int id, string category)
        {
            this.Id = id;
            this.Category = category;
        }
    }
}
