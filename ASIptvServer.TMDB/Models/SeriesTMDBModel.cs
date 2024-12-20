namespace ASIptvServer.TMDB.Models
{
public class Root
    {
        public int Page { get; set; }
        public List<SeriesTMDBModel> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }

        public Root(int page, List<SeriesTMDBModel> results, int totalPages, int totalResults)
        {
            this.Page = page;
            this.Results = results;
            this.TotalPages = totalPages;
            this.TotalResults = totalResults;
        }
    }

    public class SeriesTMDBModel
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public List<int> GenreIds { get; set; }
        public int Id { get; set; }
        public List<string> OriginCountry { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalName { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string FirstAirDate { get; set; }
        public string Name { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        public SeriesTMDBModel(bool adult, string backdropPath, List<int> genreIds, int id, List<string> originCountry, string originalLanguage, string originalName, string overview, double popularity, string posterPath, string firstAirDate, string name, double voteAverage, int voteCount)
        {
            this.Adult = adult;
            this.BackdropPath = backdropPath;
            this.GenreIds = genreIds;
            this.Id = id;
            this.OriginCountry = originCountry;
            this.OriginalLanguage = originalLanguage;
            this.OriginalName = originalName;
            this.Overview = overview;
            this.Popularity = popularity;
            this.PosterPath = posterPath;
            this.FirstAirDate = firstAirDate;
            this.Name = name;
            this.VoteAverage = voteAverage;
            this.VoteCount = voteCount;
        }
        public SeriesTMDBModel() { }
    }

}
