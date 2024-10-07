using System.Text.RegularExpressions;


namespace ASIptvServer.Naming.Renamber
{
    public class Renamber
    {
        public static string EmptyYear {  get; set; }
        public static string EmptyTrace {get; set; }
        public static string EmptyP {  get; set; }
        public static string Name { get; set; }
        public static Match Serie { get; set; }
        public static Match Year { get; set; }
        public static bool IsSerie { get; set; }

        public static Naming naming = new Naming();

        public static Naming SetNaming(NamingPath name)
        {
            EmptyYear = Regex.Replace(name.path, NamingRegex.YearString, "").Trim();
            EmptyTrace = Regex.Replace(EmptyYear, NamingRegex.RemoveTraces, "").Trim();
            EmptyP = Regex.Replace(EmptyTrace, NamingRegex.RemoveP, "").Trim();
            Name = Regex.Replace(EmptyP, NamingRegex.RemoveS, "").Trim();
            Year = NamingRegex.YearRegex.Match(name.path);
            Serie = NamingRegex.Serie.Match(name.path);
            if (Serie.Success)
            {
                IsSerie = true;
            }
            else
            {
                IsSerie = false;

            }
            naming.Name = Name;
            naming.Year = Year.Value;
            naming.IsSerie = IsSerie;
            return naming;
        }
    }
}
