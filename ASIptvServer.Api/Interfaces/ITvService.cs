using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASIptvServer.Models;

namespace ASIptvServer.Api.Interfaces
{
    public interface ITvService
    {
        List<TvModel> GetTv();
        List<TvModel> GetTvId(int id);
        void SetTv(TvModel tvModel);
        List<CategoriesModel> GetCategoryTv();
        List<TvModel> GetCategoryTvId(string category);
        void SetCategoryTv(CategoriesModel categories);
    }
}
