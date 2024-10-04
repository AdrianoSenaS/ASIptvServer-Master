namespace ASIptvServer.Naming
{
    public class Naming
    {
        public Naming() { }

        public string Name { get; set; }
        public string Lang { get; set; }
        public string Year  { get; set; }
        public bool IsSerie { get; set; }
        public Naming(string name, string lag, string year, bool isSerie) 
        {
            this.Name = name;
            this.Lang = lag;
            this.Year = year;
            this.IsSerie = isSerie;

        }
    }
}
