
using ASMedia.Shared.Model.Series;

namespace ASMedia.Shared.Interfaces.Series
{
    public interface ISeriesRepository
    {
        public Task<string> AddSerie(SeriesResponse series);
        public Task<List<SeriesResponse>> GetSeries();
        public Task<SeriesResponse> GetSerieId(int id);
        public Task<string> UpdateSerie(SeriesResponse series);
        public Task<string> DeleteSerie(int id);

    }
}
