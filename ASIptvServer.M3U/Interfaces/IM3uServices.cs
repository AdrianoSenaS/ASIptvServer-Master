using ASIptvServer.M3U.Model;

namespace ASIptvServer.M3U.Interfaces
{
    public interface IM3uServices
    {
        public List<M3uModel> M3U(string[] lines, IVerificationStrings _verificationStrings)
    }
}
