using System.Text.RegularExpressions;
using ASMedia.Naming.Model;
using ASMedia.Naming.Strings;

namespace ASMedia.Naming.Services
{
    public class NamingString 
    {
        private  static string? EmptyYear { get; set; }
        private static string? Name { get; set; }
        private static Match? Serie { get; set; }
        private static Match? Year { get; set; }
        private static bool IsSerie { get; set; }

        private static NamingModel Naming = new NamingModel();
        public static NamingModel SetNaming(NamingPathModel name)
        {
            try
            {
                if (name.Path != null)
                {
                    EmptyYear = Regex.Replace(name.Path, NamingRegex.YearString, "").Trim();
                    Name = Regex.Replace(EmptyYear, NamingRegex.RemoveS, "").Trim();
                    var ipunt = name.Path.Replace("-", "").Replace("(", "").Replace(")", "").Trim();
                    Year = NamingRegex.YearRegex.Match(ipunt);
                    Serie = NamingRegex.Serie.Match(name.Path);
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
                        Naming.Name = name.Path;
                    }
                    Naming.Name = Name;
                    Naming.Year = Year.Value;
                    Naming.IsSerie = IsSerie;
                }
                return Naming;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
