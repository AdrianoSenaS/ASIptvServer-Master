namespace ASMedia.Shared.Model.Series
{
    public class SeriesResponse
    {
        public int Id { get; set; }
        public string? Original_Name { get; set; }
        public string? Overview {  get; set; }
        public int Popularity { get; set; }
        public string? Poster_Path { get; set; }
        public string? First_Air_Date { get; set; }
        public string? Name { get; set; }
        public string? Categories { get; set; }
        public List<Genres>? Genres { get; set; }
        public int? Vote_Average { get; set; }
        public int? Vote_Count { get; set; }
        public string? Url { get; set; }
        public bool? Adult { get; set; }
    }
    public class Genres
    {
        int Id { get; set; }
        public string? Genres_Title { get; set; }
    }
}
