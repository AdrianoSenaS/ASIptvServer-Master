using System.Text.RegularExpressions;


namespace ASIptvServer.Naming
{
    public class NamingRegex
    {
        public NamingRegex() { }

        public static string YearString = @"\b\d{4}\b";
        public static Regex YearRegex = new Regex(@"\b\d{4}\b");
        public static string RemoveTraces = @"\s*-\s*";
        public static string RemoveP = @"\(\s*\)";
        public static string RemoveS = @"S\d{2} E\d{2}";
        public static Regex Serie = new Regex(@"S\d{2} E\d{2}");

    }
}
