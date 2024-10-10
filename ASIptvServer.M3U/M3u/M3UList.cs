using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ASIptvServer.M3U
{
    public class M3UList
    {

        public static List<M3U> M3uPath(M3UPath path)
        {
            List<M3U> M3uList = new List<M3U>();
            var readAll = File.ReadAllLines(path.Path);
            M3uList = GetM3Us(readAll);
            return M3uList;
        }
        public static async Task<List<M3U>> M3Uurl(M3Uurl url)
        {
            List<M3U> m3Us = new List<M3U>();
            try
            {
                using HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(url.Url);
                string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                m3Us = GetM3Us(lines);
            }
            catch (Exception)
            {
                throw;
            }
            return m3Us;
        }

        private static List<M3U> GetM3Us(string[] lines)
        {
            List<M3U> m3Us = new List<M3U>();
            try
            {
                int Id = 0;
               
                // Iterar sobre as linhas
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    if (lines[i].StartsWith("#EXTINF"))
                    {
                        var m3U = new M3U();
                        Id++;
                        bool radio = false;
                        m3U.Serie = false;
                        m3U.Tv =false;
                        m3U.Radio = false;
                        m3U.Movies = false;
                        // Aplicar regex na linha #EXTINF
                        string streamUrl = lines[i + 1];
                        // A linha seguinte contém a URL
                        var matchFormatVideo = M3uRegex.FormatVideo.Match(streamUrl);
                        var matchSeries = M3uRegex.FilterSeries.Match(streamUrl);
                        var matchFormatRadio = M3uRegex.FormatRadio.Match(streamUrl);
                        var result = VerificatioString(matchFormatVideo, matchSeries, matchFormatRadio);
                        Match match = Regex.Match(lines[i], M3uRegex.M3UTags);
                        var regex = new Regex(@",(.+)");
                        var regex3 = new Regex(@"group-title=""(.*?)"",(.+)");
                        var regex4 = new Regex(@"tvg-logo=""(.*?)"",(.+)");
                        var regex2 = new Regex(@"tvg-logo=""(.*?)"".*?group-title=""(.*?)"",(.+)");
                        var regex0 = new Regex(@"tvg-name=""(.*?)"".*?group-title=""(.*?)"".*?radio=""(.*?)"".*?tvg-logo=""(.*?)"",(.+)");
                        var match1 = regex.Match(lines[i]);
                        var match3 = regex3.Match(lines[i]);
                        var match2 = regex2.Match(lines[i]);
                        var match0 = regex0.Match(lines[i]);
                        var match4 = regex4.Match(lines[i]);
                        if (match1.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match1.Groups[1].Value.Trim();
                            m3U.Url = streamUrl;
                            //Console.WriteLine(m3U.Name);
                            //Console.WriteLine(m3U.Url);
                        }
                        if (match3.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match3.Groups[2].Value.Trim();
                            m3U.Categories = match3.Groups[1].Value.Trim();
                            m3U.Url = streamUrl;
                            /* Console.WriteLine(m3U.Name);
                             Console.WriteLine(m3U.Categories);
                             Console.WriteLine(m3U.Url);*/
                        }
                        if (match4.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match4.Groups[2].Value.Trim();
                            m3U.Logo = match4.Groups[1].Value.Trim();
                            m3U.Url = streamUrl;
                            //Console.WriteLine(m3U.Name);
                            //Console.WriteLine(m3U.Categories);
                            //Console.WriteLine(m3U.Url);
                        }
                        if (match2.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match2.Groups[3].Value.Trim();
                            m3U.Logo = match2.Groups[1].Value;
                            m3U.Categories = match2.Groups[2].Value.Trim();
                            m3U.Url = streamUrl;
                            //Console.WriteLine(m3U.Name);
                            //Console.WriteLine(m3U.Categories);
                            //Console.WriteLine(m3U.Url);
                        }
                        if (match0.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match0.Groups[5].Value.Trim();
                            m3U.Logo = match0.Groups[4].Value.Trim();
                            m3U.Categories = match0.Groups[2].Value.Trim();
                            m3U.Url = streamUrl;
                            //Console.WriteLine(m3U.Name);
                            //Console.WriteLine(m3U.Categories);
                            //Console.WriteLine(m3U.Url);
                        }
                        if (match.Success)
                        {
                            m3U.Id = Id;
                            m3U.Name = match.Groups[4].Value;
                            m3U.Logo = match.Groups[2].Value;
                            m3U.Categories = match.Groups[3].Value;
                            m3U.Url = streamUrl;
                            //Console.WriteLine(m3U.Name);
                            //Console.WriteLine(m3U.Categories);
                            //Console.WriteLine(m3U.Url);
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
            catch (Exception)
            {
                throw;
            }
        }
        private static string VerificatioString(Match formatVideo, Match formatSeries, Match FormatRadio)
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

            return "";
        }
    }
}
