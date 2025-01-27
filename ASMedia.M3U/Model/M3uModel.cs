namespace ASMedia.M3U.Model
{
    public class M3uModel
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Categories { get; set; }
        public string? Url { get; set; }
        public bool Movies { get; set; }
        public bool Serie { get; set; }
        public bool Tv { get; set; }
        public bool Radio { get; set; }
      
    }
}
