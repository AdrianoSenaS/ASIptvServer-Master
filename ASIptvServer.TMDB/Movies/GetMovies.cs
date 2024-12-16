using ASIptvServer.TMDB.Api;
using ASIptvServer.TMDB.Models;
using RestSharp;
using static ASIptvServer.TMDB.Models.Root;

namespace ASIptvServer.TMDB
{
    public  interface ITMDBMovie
    {
        MovieTMDBModel GetFilms(string name, string year);
    }
    public class GetMovies : ITMDBMovie
    {
        public MovieTMDBModel film = new MovieTMDBModel();
        public  ApiHeadersModel apiHeaders = new ApiHeadersModel();
        public MovieTMDBModel GetFilms(string name, string year)
        {
            try
            {
                apiHeaders.Options = $"https://api.themoviedb.org/3/search/movie?query={name}&include_adult=true&language=pt-BR&page=1&year={year}";
                apiHeaders.Token = "Bearer token aqui";
                apiHeaders.HeaderContentType = "application/json";

                var result = TMDBApi.Api(apiHeaders);
                var request = result.restRequest;
                var response = result.restClient.Get<Root>(request);
                foreach (var item in response.Results)
                {
                    film = item;
                }
                return film;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
