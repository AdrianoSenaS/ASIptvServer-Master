using ASIptvServer.Api.Interfaces;
using ASIptvServer.Api.Models;

namespace ASIptvServer.Api.Services.Tv
{
    public interface ITvServices
    {
        void TV(M3U.M3U item);
    }
    public class TvServices: ITvServices
    {
        private readonly ITvService _tvService;
        public TvServices(ITvService tvService)
        {
            _tvService = tvService;
        }
        public void TV(M3U.M3U item)
        {
            TvModel tv = new TvModel();
            CategoriesModel categories = new CategoriesModel();
            tv.Id = item.Id;
            tv.Title = item.Name;
            tv.Logo = item.Logo;
            tv.Categories = item.Categories;
            tv.Url = item.Url;
            _tvService.SetTv(tv);
            categories.Category = item.Categories;
            _tvService.SetCategoryTv(categories);
            Console.WriteLine("Resultado: " + item.Name);
        }
    }
}
