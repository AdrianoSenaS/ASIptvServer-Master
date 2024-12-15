
namespace ASIptvServer.Models
{
   public class CategoriesModel
    {
        public CategoriesModel() { }
        public int Id { get; set; }
        public string Category { get; set; }
        public string SubCatagory { get; set; }
        public CategoriesModel(int id, 
            string category, 
            string subCatagory)
        {
            this.Id = id;
            this.Category = category;
            this.SubCatagory = subCatagory;
        }
    }
}
