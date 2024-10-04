using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIptvServer.M3U.M3u
{
    public class M3UDownload
    {
        public static async Task<string> DownloadM3U(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Obter o conteúdo da URL
                    return await client.GetStringAsync(url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao baixar M3U: {ex.Message}");
                    return string.Empty;
                }
            }
        }
    }
}
