using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASIptvServer.Models;

namespace ASIptvServer.Api.Interfaces
{
    public interface ISeriesService
    {
        List<SeriesModel> GetSeries();
        List<SeriesModel> GetDbSeriesId(int id);
        void SetSeries(SeriesModel series);
        List<CategoriesModel> GetCateoriesSeries();
        List<SeriesModel> GetCategoriesSeriesId(string category);
        void SetCategorySeries(CategoriesModel category);
    }
}
