using ASMedia.M3U.Interfaces;
using ASMedia.M3U.Model;
using ASMedia.Shared.M3U;

namespace ASMedia.M3U.Application
{
    public class M3uFilePath
    {
        private readonly IM3uServices _services;
        private M3uFilePath(IM3uServices m3UServices)
        {
            _services = m3UServices;
        }
        public M3UResponse GetM3U(M3uPathResponse path)
        {
            M3UResponse m3UResponses = new M3UResponse();
            M3uModel M3uList = new M3uModel();
            if (path.Path != null)
            {
                var readAll = File.ReadAllLines(path.Path);
                m3UResponses.Id = M3uList.Id;
                M3uList = _services.M3U(readAll);
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
    }
}
