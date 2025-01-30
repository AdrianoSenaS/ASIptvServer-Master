
using ASMedia.Shared.Model.Tv;

namespace ASMedia.Shared.Interfaces.Tv
{
    public interface ITvRepository
    {
        public Task<string> AddTv(TvResponse tv);
        public Task<List<TvResponse>> GetTv();
        public Task<TvResponse> GetTvId(int id);
        public Task<string> UpdateTv(TvResponse tv);
        public Task<string> DeleteTv(int id);
    }
}
