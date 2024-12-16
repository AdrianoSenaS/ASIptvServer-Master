using ASIptvServer.TMDB.Api;
using ASIptvServer.TMDB.Models;
using RestSharp;

namespace ASIptvServer.TMDB
{
    public  interface ITMDBMovie
    {
        MovieTMDBModel GetMovie(string name, string year);
    }
    public class GetMovies : ITMDBMovie
    {
        public MovieTMDBModel movie = new MovieTMDBModel();
        public  ApiHeadersModel apiHeaders = new ApiHeadersModel();
        public MovieTMDBModel GetMovie(string name, string year)
        {
            try
            {
                Console.WriteLine("Buscando na APi");
                apiHeaders.Options = $"https://api.themoviedb.org/3/search/movie?query={name}&include_adult=true&language=pt-BR&page=1&year={year}";
                apiHeaders.Token = "Bearer ";
                apiHeaders.HeaderContentType = "application/json";

                var result = TMDBApi.Api(apiHeaders);
                var request = result.restRequest;
                var response = result.restClient.Get<Root>(request);
                foreach (var item in response.Results)
                {
                    movie = item;
                }
                return movie;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
