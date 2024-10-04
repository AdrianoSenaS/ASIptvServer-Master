using System.Text.RegularExpressions;

namespace ASIptvServer.M3U
{
    public class AsRegex
    {
        public static string M3UTags = @"tvg-id=""(.*?)"".*?tvg-name=""(.*?)"".*?tvg-logo=""(.*?)"".*?group-title=""(.*?)"",(.+)";
        public static Regex FormatVideo = new Regex(@"\.(mp4|mkv|avi)$");
        public static Regex FilterSeries = new Regex("series");
    }
}
