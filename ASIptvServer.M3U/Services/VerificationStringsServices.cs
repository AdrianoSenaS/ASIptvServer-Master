using System.Text.RegularExpressions;
using ASIptvServer.M3U.Interfaces;

namespace ASIptvServer.M3U.Services
{
    public class VerificationStringsServices : IVerificationStrings
    {
        public string Verification(Match formatVideo, Match formatSeries, Match FormatRadio)
        {
            if (formatVideo.Success && !formatSeries.Success && !FormatRadio.Success)
            {
                return "movie";
            }
            if (formatSeries.Success)
            {
                return "serie";
            }
            if (FormatRadio.Success)
            {
                return "radio";
            }
            return "other";
        }
    }
}
