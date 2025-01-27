using System.Text.RegularExpressions;
using ASMedia.Shared.Model;
using ASMedia.Naming.Strings;
using ASMedia.Shared.Interfaces.Naming;
using ASMedia.Shared.Model.Naming;

namespace ASMedia.Naming.Services
{
    public class NamingString : INamingRepository
    {
        private string? EmptyYear { get; set; }
        private string? Name { get; set; }
        private Match? Serie { get; set; }
        private Match? Year { get; set; }
        private bool IsSerie { get; set; }

        private NamingResponse Naming = new NamingResponse();
        public NamingResponse GetNaming(NamingPathCreate name)
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
