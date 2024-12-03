using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.Data
{
   public class Categories
    {
        public Categories() { }
        public int Id { get; set; }
        public string Category { get; set; }
        public string SubCatagory { get; set; }
        public Categories(int id, 
            string category, 
            string subCatagory)
        {
            this.Id = id;
            this.Category = category;
            SubCatagory = subCatagory;
        }
    }
}
