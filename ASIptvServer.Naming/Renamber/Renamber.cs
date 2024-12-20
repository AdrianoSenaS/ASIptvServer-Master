using System.Text.RegularExpressions;


namespace ASIptvServer.Naming.Renamber
{
    public class Renamber
    {
        public static string? EmptyYear { get; set; }
        public static string? Name { get; set; }
        public static Match? Serie { get; set; }
        public static Match? Year { get; set; }
     
        public static bool IsSerie { get; set; }

        public static Naming naming = new Naming();

        public static Naming SetNaming(NamingPath name)
        {
            try
            {
                EmptyYear = Regex.Replace(name.path, NamingRegex.YearString, "").Trim();
                Name = Regex.Replace(EmptyYear, NamingRegex.RemoveS, "").Trim();
                var ipunt = name.path.Replace("-", "").Replace("(", "").Replace(")", "").Trim();
                Year = NamingRegex.YearRegex.Match(ipunt);
                Serie = NamingRegex.Serie.Match(name.path);
                if (Serie.Success)
                {
                    IsSerie = true;
                }
                else
                {
                    IsSerie = false;

                }
                if (EmptyYear == string.Empty || Name == string.Empty)
                {
                    naming.Name = name.path;
                }
                naming.Name = Name;
                naming.Year = Year.Value;
                naming.IsSerie = IsSerie;
                return naming;
            }
            catch (Exception)
            {
                return naming;
            }
        }
    }
}
