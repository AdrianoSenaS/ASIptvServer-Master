using ASMedia.M3U.Interfaces;
using ASMedia.M3U.Model;

namespace ASMedia.M3U
{
    public class M3uUrl
    {
        private readonly IVerificationStrings _verificationStrings;
        private readonly IM3uServices _services;
        public M3uUrl(IVerificationStrings verificationStrings, IM3uServices m3UServices)
        {
            _verificationStrings = verificationStrings;
            _services = m3UServices;
        }
       
        public async Task<List<M3uModel>> GetM3u(M3uUrlModel url)
        {
            List<M3uModel> m3Us = new List<M3uModel>();
            try
            {
                using HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(url.Url);
                string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                m3Us = _services.M3U(lines, _verificationStrings);
            }
            catch (Exception)
            {
                throw;
            }
            return m3Us;
        }
    }
}
