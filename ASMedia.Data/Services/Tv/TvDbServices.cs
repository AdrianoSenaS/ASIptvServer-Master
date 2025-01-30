using ASMedia.Data.DataDbContext;
using ASMedia.Shared.Interfaces.Tv;
using ASMedia.Shared.Model.Tv;
using Microsoft.EntityFrameworkCore;
namespace ASMedia.Data.Services.Tv
{
    public class TvDbServices: ITvRepository
    {
        private readonly AppDbContext DbContext;

        public TvDbServices(AppDbContext dbContext) 
        {
            DbContext = dbContext;
        }
        public async Task<string> AddTv(TvResponse tv)
        {
            try
            {
                await DbContext.Tv.AddAsync(tv);
                await DbContext.SaveChangesAsync();
                return "Ok";
            }
            catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<List<TvResponse>> GetTv()
        {
            try
            {
                List<TvResponse> tv = await DbContext.Tv.ToListAsync();
                return tv;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<TvResponse> GetTvId(int id)
        {
            try
            {
                TvResponse? tv = await DbContext.Tv.FirstOrDefaultAsync(x=>x.Id == id);
                if (tv!= null)
                {
                    return tv;
                }
                else
                {
                    throw new Exception("Canal não encontrado");
                }
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> UpdateTv(TvResponse tv)
        {
            try
            {
                TvResponse response = await GetTvId(tv.Id);
                if (response != null)
                {
                    DbContext.Entry(tv).State = EntityState.Detached;
                    DbContext.Update(response);
                    DbContext.SaveChanges();
                    return "Ok";
                }
                else
                {
                    throw new Exception("Canal não encontrado");
                }
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        public async Task<string> DeleteTv(int id)
        {
            try
            {
                TvResponse tv = await GetTvId(id);
                if (tv != null)
                {
                    DbContext.Remove(tv);
                    DbContext.SaveChanges();
                    return "Ok";
                }
                else
                {
                    throw new Exception("Canal não encontrado");
                }
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    } 
}
