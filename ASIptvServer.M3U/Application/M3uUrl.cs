using ASMedia.M3U.Interfaces;
using ASMedia.M3U.Model;
using ASMedia.Shared.M3U;

namespace ASMedia.M3U
{
    public class M3uUrl
    {

        private readonly IM3uServices _services;
        public M3uUrl(IM3uServices m3UServices)
        {
            _services = m3UServices;
        }

        public async Task<M3UResponse> GetM3u(M3uUrlResponse url)
        {
            M3UResponse m3UResponses = new M3UResponse();
            M3uModel M3uList = new M3uModel();
            try
            {
                using HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(url.Url);
                string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                M3uList = _services.M3U(lines);
                m3UResponses.Id = M3uList.Id;
                m3UResponses.Name = M3uList.Name;
                m3UResponses.Logo = M3uList.Logo;
                m3UResponses.Movies = M3uList.Movies;
                m3UResponses.Tv = M3uList.Tv;
                m3UResponses.Categories = M3uList.Categories;
                m3UResponses.Url = M3uList.Url;
                m3UResponses.Radio = M3uList.Radio;
                m3UResponses.Serie = M3uList.Serie;
                return m3UResponses;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
