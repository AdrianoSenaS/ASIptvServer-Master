using RestSharp;
namespace ASIptvServer.TMDB.Api
{
    public class TMDBApi
    {
        public static ApiRest api = new ApiRest();
        public static ApiRest Api(ApiHeaders headers)
        {
            var options = new RestClientOptions(headers.Options); 
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("Accept", headers.HeaderContentType);
            request.AddHeader("Authorization", headers.Token);
            api.restClient = client;
            api.restRequest = request;
            return api;
        }
    }
}
