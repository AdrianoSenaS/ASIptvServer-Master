namespace ASMedia.Shared.Model.M3U
{
    public class M3UResponse
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
