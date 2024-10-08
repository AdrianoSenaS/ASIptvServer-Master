using ASIptvServer.M3U.M3u;
using ASIptvServer.IO.FilesServer;
using ASIptvServer.IO;
using ASIptvServer.M3U;
using ASIptvServer.Naming.Renamber;
using ASIptvServer.Naming;
using ASIptvServer.Data.Data;

namespace ASIptvServer.Api.Models
{
    public class M3uUrlModel
    {
        public static string pathM3u = @"C:\temp\ASIptvServer\lista.m3u";

        public static async void UpdateM3u(string url)
        {
            var m3uPath = await UrlM3U.GetM3Uurl(url);
            path path = new path(pathM3u);
            Files.CreateFile(path, m3uPath);
            M3UPath m3UPath = new M3UPath(pathM3u);
            var dt = M3UList.M3u(m3UPath);
            foreach (var item in dt)
            {
                NamingPath namingPath = new NamingPath(item.Name);
                var result = Renamber.SetNaming(namingPath);
                if (!item.Tv && !item.Serie)
                {
                    DbMovies.SetMovies(result.Name, item.Logo, item.Categories, string.Empty, item.Url, result.Year);
                    Console.WriteLine("Adicionando: "+result.Name);
                }
            }
        }
    }
}
