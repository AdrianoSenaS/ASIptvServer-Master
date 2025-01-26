namespace ASIptvServer.Naming.Model
{
    public class NamingModel
    {
        public NamingModel() { }

        public string Name { get; set; }
        public string Lang { get; set; }
        public string Year { get; set; }
        public bool IsSerie { get; set; }
        public NamingModel(string name,
            string lag,
            string year,
            bool isSerie)
        {
            Name = name;
            Lang = lag;
            Year = year;
            IsSerie = isSerie;

        }
    }
}
