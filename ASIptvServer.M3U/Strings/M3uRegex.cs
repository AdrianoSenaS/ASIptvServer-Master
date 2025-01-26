using System.Text.RegularExpressions;

namespace ASIptvServer.M3U.Strings
{
    public class M3uRegex
    {
        public static Regex regex = new Regex(@",(.+)");
        public static Regex FilterSeries = new Regex("series");
        public static Regex FormatRadio = new Regex(@"\.(mp3)$");
        public static Regex FormatVideo = new Regex(@"\.(mp4|mkv|avi)$");
        public static Regex regex4 = new Regex(@"tvg-logo=""(.*?)"",(.+)");
        public static Regex regex3 = new Regex(@"group-title=""(.*?)"",(.+)");
        public static Regex regex2 = new Regex(@"tvg-logo=""(.*?)"".*?group-title=""(.*?)"",(.+)");
        public static string M3UTags = @"tvg-name=""(.*?)"".*?tvg-logo=""(.*?)"".*?group-title=""(.*?)"",(.+)";
        public static Regex regex0 = new Regex(@"tvg-name=""(.*?)"".*?group-title=""(.*?)"".*?radio=""(.*?)"".*?tvg-logo=""(.*?)"",(.+)");
    }
}
