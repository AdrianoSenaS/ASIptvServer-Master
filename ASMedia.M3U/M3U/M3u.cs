using ASMedia.M3U.Services;
using ASMedia.Shared.Interfaces.M3U;
using ASMedia.Shared.Model.M3U;

namespace ASMedia.M3U.Application
{
    public class M3u : IM3uRepository
    {
        public M3UResponse GetM3UFilePath(M3uPathResponse path)
        {
            if (path.Path != null)
            {
                var readAll = File.ReadAllLines(path.Path);
                M3UResponse m3UResponses = M3uServices.M3U(readAll);
                return m3UResponses;
            }
            else
            {
                throw new Exception("Não encontrado");
            }
        }
        public async Task<M3UResponse> GetM3uUrl(M3uUrlResponse url)
        {
            try
            {
                M3UResponse m3UResponses = new M3UResponse();
                using HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(url.Url);
                string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                m3UResponses = M3uServices.M3U(lines);
                return m3UResponses;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
