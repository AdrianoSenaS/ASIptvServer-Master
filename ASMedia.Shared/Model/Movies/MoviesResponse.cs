
namespace ASMedia.Shared.Model.Movies
{
    public class MoviesResponse
    {
        public int Id { get; set; }
        public int Id_TMDB { get; set; }
        public string? Original_Title { get; set; }
        public string? Overview { get; set; }
        public int? Popularity { get; set; }
        public string? Poster_Path {  get; set; }
        public string? Release_Date { get; set; }
        public string? Title { get; set; }
        public string? Categories { get; set; }
        public List<Genres>? Genres { get; set; }
        public int? Vote_Average { get; set; }
        public int? Vote_Count { get; set; }
    }
    public class Genres
    {
        int Id  { get; set; }
        public string? Genres_Title { get; set; }
    }

}
