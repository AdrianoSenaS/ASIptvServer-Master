using System.Text.RegularExpressions;
using ASMedia.M3U.Interfaces;
using ASMedia.M3U.Model;
using ASMedia.M3U.Strings;

namespace ASMedia.M3U.Services
{
    public class M3uServices : IM3uServices
    {
        public List<M3uModel> M3U(string[] lines, IVerificationStrings _verificationStrings )
        {
            List<M3uModel> m3Us = new List<M3uModel>();
            try
            {
                int Id = 0;
                // Iterar sobre as linhas
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    if (lines[i].StartsWith("#EXTINF"))
                    {
                        var m3U = new M3uModel();
                        Id++;
                        m3U.Serie = false;
                        m3U.Tv = false;
                        m3U.Radio = false;
                        m3U.Movies = false;
                        // Aplicar regex na linha #EXTINF
                        string streamUrl = lines[i + 1];
                        // A linha seguinte contém a URL
                        var matchFormatVideo = M3uRegex.FormatVideo.Match(streamUrl);
                        var matchSeries = M3uRegex.FilterSeries.Match(streamUrl);
                        var matchFormatRadio = M3uRegex.FormatRadio.Match(streamUrl);
                        var result = _verificationStrings.Verification(matchFormatVideo, matchSeries, matchFormatRadio);
                        Match match = Regex.Match(lines[i], M3uRegex.M3UTags);
                        var match1 = M3uRegex.regex.Match(lines[i]);
                        var match3 = M3uRegex.regex3.Match(lines[i]);
                        var match2 = M3uRegex.regex2.Match(lines[i]);
                        var match0 = M3uRegex.regex0.Match(lines[i]);
                        var match4 = M3uRegex.regex4.Match(lines[i]);
                        if (match1.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match1.Groups[1].Value.Trim();
                            m3U.Url = streamUrl;
                        }
                        if (match3.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match3.Groups[2].Value.Trim();
                            m3U.Categories = match3.Groups[1].Value.Trim();
                            m3U.Url = streamUrl;
                        }
                        if (match4.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match4.Groups[2].Value.Trim();
                            m3U.Logo = match4.Groups[1].Value.Trim();
                            m3U.Url = streamUrl;
                        }
                        if (match2.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match2.Groups[3].Value.Trim();
                            m3U.Logo = match2.Groups[1].Value;
                            m3U.Categories = match2.Groups[2].Value.Trim();
                            m3U.Url = streamUrl;
                        }
                        if (match0.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match0.Groups[5].Value.Trim();
                            m3U.Logo = match0.Groups[4].Value.Trim();
                            m3U.Categories = match0.Groups[2].Value.Trim();
                            m3U.Url = streamUrl;
                        }
                        if (match.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match.Groups[4].Value;
                            m3U.Logo = match.Groups[2].Value;
                            m3U.Categories = match.Groups[3].Value;
                            m3U.Url = streamUrl;
                        }
                        if (result == "movie")
                        {
                            m3U.Movies = true;
                        }
                        if (result == "serie")
                        {
                            m3U.Serie = true;
                        }
                        if (result == "radio")
                        {
                            m3U.Radio = true;
                        }
                        if (result == "")
                        {
                            m3U.Tv = true;
                        }
                        m3Us.Add(m3U);
                    }
                }
                return m3Us;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
