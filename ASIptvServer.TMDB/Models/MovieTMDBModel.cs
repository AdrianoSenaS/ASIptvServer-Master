public class Root
{
    public int Page { get; set; }
    public List<MovieTMDBModel> Results { get; set; }
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }

    public Root(int page, List<MovieTMDBModel> results, int totalPages, int totalResults)
    {
        this.Page = page;
        this.Results = results;
        this.TotalPages = totalPages;
        this.TotalResults = totalResults;
    }
}
public class MovieTMDBModel
{
    public bool Adult { get; set; }
    public string backdrop_path { get; set; }
    public List<int> GenreIds { get; set; }
    public int Id { get; set; }
    public string OriginalLanguage { get; set; }
    public string OriginalTitle { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public string poster_path { get; set; }
    public string ReleaseDate { get; set; } // Pode ser ajustado para DateTime, se necessário
    public string Title { get; set; }
    public bool Video { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }

    public MovieTMDBModel(bool adult, string backdropPath, List<int> genreIds, int id, string originalLanguage, string originalTitle, string overview, double popularity, string posterPath, string releaseDate, string title, bool video, double voteAverage, int voteCount)
    {
        this.Adult = adult;
        this.backdrop_path = backdropPath;
        this.GenreIds = genreIds;
        this.Id = id;
        this.OriginalLanguage = originalLanguage;
        this.OriginalTitle = originalTitle;
        this.Overview = overview;
        this.Popularity = popularity;
        this.poster_path = posterPath;
        this.ReleaseDate = releaseDate;
        this.Title = title;
        this.Video = video;
        this.VoteAverage = voteAverage;
        this.VoteCount = voteCount;
    }
    public MovieTMDBModel()
    {
    }
}
