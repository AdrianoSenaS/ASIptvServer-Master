using ASMedia.M3U.Model;
using ASMedia.M3U.Services;
using ASMedia.Shared.Interfaces.M3U;
using ASMedia.Shared.Model.M3U;
using ASMedia.Shared.Interfaces;

namespace ASMedia.M3U.Application
{
    public class M3u : IM3u
    {
     
      
        public M3UResponse GetM3UFilePath(M3uPathResponse path)
        {
            M3UResponse m3UResponses = new M3UResponse();
            M3uModel M3uList = new M3uModel();
            if (path.Path != null)
            {
                var readAll = File.ReadAllLines(path.Path);
                m3UResponses.Id = M3uList.Id;
                M3uList = M3uServices.M3U(readAll);
                m3UResponses.Name = M3uList.Name;
                m3UResponses.Logo = M3uList.Logo;
                m3UResponses.Movies = M3uList.Movies;
                m3UResponses.Tv = M3uList.Tv;
                m3UResponses.Categories = M3uList.Categories;
                m3UResponses.Url = M3uList.Url;
                m3UResponses.Radio = M3uList.Radio;
                m3UResponses.Serie = M3uList.Serie;
            }
            return m3UResponses;
        }
        public async Task<M3UResponse> GetM3uUrl(M3uUrlResponse url)
        {
            M3UResponse m3UResponses = new M3UResponse();
            M3uModel M3uList = new M3uModel();
            try
            {
                using HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(url.Url);
                string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                M3uList = M3uServices.M3U(lines);
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
