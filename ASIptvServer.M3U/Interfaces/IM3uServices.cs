using ASMedia.M3U.Model;

namespace ASMedia.M3U.Interfaces
{
    public interface IM3uServices
    {
        public List<M3uModel> M3U(string[] lines, IVerificationStrings _verificationStrings)
    }
}
