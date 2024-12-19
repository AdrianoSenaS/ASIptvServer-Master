using ASIptvServer.Api.Models;

namespace ASIptvServer.Api.Interfaces
{
    public interface ISeriesService
    {
        List<SeriesModel> GetSeries();
        SeriesModel GetDbSeriesId(int id);
        void SetSeries(SeriesModel series);
        List<CategoriesModel> GetCateoriesSeries();
        List<SeriesModel> GetCategoriesSeriesId(string category);
        void SetCategorySeries(CategoriesModel category);
    }
}
