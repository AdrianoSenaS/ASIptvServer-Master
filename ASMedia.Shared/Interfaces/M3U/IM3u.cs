
using ASMedia.Shared.Model.M3U;

namespace ASMedia.Shared.Interfaces.M3U
{
    public interface IM3u
    {
        public M3UResponse GetM3UFilePath(M3uPathResponse path);
        public Task<M3UResponse> GetM3uUrl(M3uUrlResponse url);
    }
}
