namespace ASIptvServer.TMDB
{
    public class Movie
    {

        public Movie() { }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public List<int> GenreIds { get; set; }
        public int Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        public Movie(bool adult, string backdropPath, List<int> genreIds,
            int id, string originalLanguage, string originalTitle, string overview,
            double popularity, string posterPath, string releaseDate, string title,
            bool video, double voteAverage, int voteCount
            )
        {
            this.Adult = adult;
            this.BackdropPath = backdropPath;
            this.PosterPath = posterPath;
            this.Overview = overview;
            this.Id = id;
            this.OriginalLanguage = originalLanguage;
            this.Title = title;
            this.GenreIds = genreIds;
            this.Video = video;
            this.ReleaseDate = releaseDate;
            this.VoteAverage = voteAverage;
            this.VoteCount = voteCount;
            this.Popularity = popularity;
            this.OriginalTitle = originalTitle;
        }


        public class ApiResponse
        {
            public int Page { get; set; }
            public List<Movie> Results { get; set; }
            public int TotalPages { get; set; }
            public int TotalResults { get; set; }
        }
    }
}
