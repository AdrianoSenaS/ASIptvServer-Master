using ASMedia.M3U.Interfaces;
using ASMedia.M3U.Model;

namespace ASMedia.M3U.Application
{
    public class M3uFilePath
    {
        private readonly IM3uServices _services;
        private M3uFilePath(IM3uServices m3UServices)
        {
            _services = m3UServices;
        }
        public List<M3uModel> GetM3U(M3uPathModel path)
        {
            List<M3uModel> M3uList = new List<M3uModel>();
            var readAll = File.ReadAllLines(path.Path);
            M3uList = _services.M3U(readAll);
            return M3uList;
        }
    }
}
