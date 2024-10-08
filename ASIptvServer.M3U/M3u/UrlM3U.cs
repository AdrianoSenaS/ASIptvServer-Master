
namespace ASIptvServer.M3U.M3u
{
    public class UrlM3U
    {
        public static async Task<string> GetM3Uurl(string url)
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

                    return string.Empty;
                }
            }
        }
    }
}
