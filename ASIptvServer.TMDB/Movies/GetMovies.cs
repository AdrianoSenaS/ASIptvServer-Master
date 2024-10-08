namespace ASIptvServer.TMDB
{
    public class GetMovies
    {
        public static List<Movie> film = new List<Movie>();
        public static ApiHeaders apiHeaders = new ApiHeaders();
        public static List<Movie> GetFilms()
        {
            try
            {


                return film;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
