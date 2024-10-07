using System.Text.RegularExpressions;

namespace ASIptvServer.M3U
{
    public class M3UList
    {
        
        public static  List<M3U> M3u(string path)
        {
            int Id = 0;
            M3U m3U = null;
            List<M3U> M3uList = new List<M3U>();
            var readAll = File.ReadLines(path);

            foreach (var line in readAll)
            {
               
                if (line.StartsWith("#EXTINF"))
                {
                    m3U = new M3U();
                    Regex regex = new Regex(AsRegex.M3UTags);
                    var match = regex.Match(line);
                    if (match.Success)
                    {
                        Id++;
                        m3U.Id =Id;
                        m3U.Name = match.Groups[5].Value;
                        m3U.Logo = match.Groups[3].Value;
                        m3U.Categories = match.Groups[4].Value;
                    }
                }
                else if (line.StartsWith("http") && m3U != null)
                {
                    var matchFormatVideo = AsRegex.FormatVideo.Match(line);
                    var matchSeries = AsRegex.FilterSeries.Match(line);
                    if (!matchSeries.Success || !matchFormatVideo.Success)
                    {
                        m3U.Movies = false;
                        m3U.Serie = false;
                        m3U.Tv = true;
                    }
                    if (matchSeries.Success && matchFormatVideo.Success)
                    {
                        m3U.Movies = false;
                        m3U.Serie = true;
                        m3U.Tv = false;
                    }
                    if (!matchSeries.Success && matchFormatVideo.Success)
                    {
                        m3U.Movies = true;
                        m3U.Serie = false;
                        m3U.Tv = false;
                    }
                    m3U.Url = line;
                    M3uList.Add(m3U);
                }
            }
            return  M3uList;
        }
    }
}
