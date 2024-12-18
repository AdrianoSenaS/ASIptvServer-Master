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
                apiHeaders.Options = $"https://api.themoviedb.org/3/search/movie?query={name}&include_adult=true&language=pt-BR&page=1&year={year}";
                apiHeaders.Token = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzMWEzMzM5Yjg1MGE0ZDI4NDNiMjU5ZmI5ZWJiYTNmZiIsIm5iZiI6MTcyNzIxNjM0NC42OCwic3ViIjoiNjZmMzNhZDg1MDUxMzI4MzBlMjE2NDFhIiwic2NvcGVzIjpbImFwaV9yZWFkIl0sInZlcnNpb24iOjF9.ymyuM-JNxbypJmoe1ByMoONM24elHMV_053-HYEQxl0";
                apiHeaders.HeaderContentType = "application/json";
                var api = TMDBApi.Api(apiHeaders);
                var request = api.restRequest;
                var response = api.restClient.Get<Root>(request);
                foreach (var item in response.Results)
                {
                    if (name == item.original_title || name == item.Title)
                    {
                        movie = item;
                    }
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
