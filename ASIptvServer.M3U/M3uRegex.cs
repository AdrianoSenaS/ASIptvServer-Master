using System.Text.RegularExpressions;

namespace ASIptvServer.M3U
{
    public class M3uRegex
    {
        public static string M3UTags = @"tvg-name=""(.*?)"".*?tvg-logo=""(.*?)"".*?group-title=""(.*?)"",(.+)";
        public static Regex FormatVideo = new Regex(@"\.(mp4|mkv|avi)$");
         public static Regex FormatRadio = new Regex(@"\.(mp3)$");
        public static Regex FilterSeries = new Regex("series");
    }
}
