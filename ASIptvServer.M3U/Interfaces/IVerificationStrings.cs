using System.Text.RegularExpressions;

namespace ASIptvServer.M3U.Interfaces
{
   
    public interface IVerificationStrings
    {
        public string Verification(Match formatVideo, Match formatSeries, Match FormatRadio);

    }
}
