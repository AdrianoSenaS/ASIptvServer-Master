using ASMedia.Data.DataDbContext;
using ASMedia.Shared.Interfaces.Series;
using ASMedia.Shared.Model.Series;
using Microsoft.EntityFrameworkCore;

namespace ASMedia.Data.Services.Series
{
    public class SeriesDbServices: ISeriesRepository
    {
        private readonly AppDbContext DbContext;
        public SeriesDbServices(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<string> AddSerie(SeriesResponse series)
        {
            try
            {
                await DbContext.Series.AddAsync(series);
                await DbContext.SaveChangesAsync();
                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<List<SeriesResponse>> GetSeries()
        {
            try
            {
                List<SeriesResponse> series = await DbContext.Series.ToListAsync();
                if (series != null)
                {
                    return series;
                }
                else
                {
                    throw new Exception("Nenhuma série encontrada");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<SeriesResponse> GetSerieId(int id)
        {
            try
            {
                SeriesResponse? series = await DbContext.Series.FirstOrDefaultAsync(x => x.Id == id);
                if (series != null)
                {
                    return series;
                }
                else
                {
                    throw new Exception("Nenhuma série encontrada");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> UpdateSerie(SeriesResponse series)
        {
            try
            {
                SeriesResponse response = await GetSerieId(series.Id);
                if (response != null)
                {
                    DbContext.Entry(series).State = EntityState.Detached;
                    DbContext.Update(series);
                    DbContext.SaveChanges();
                    return "Ok";
                }
                else
                {
                    throw new Exception("Série não encontrada");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> DeleteSerie(int id)
        {
            try
            {
                SeriesResponse series = await GetSerieId(id);
                if (series != null)
                {
                    DbContext.Remove(series);
                    DbContext.SaveChanges();
                    return "Ok";
                }
                else
                {
                    throw new Exception("Filme não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
