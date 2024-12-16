using ASIptvServer.TMDB.Models;
using RestSharp;
namespace ASIptvServer.TMDB.Api
{
    public class TMDBApi
    {
        public static ApiRestModel api = new ApiRestModel();
        public static ApiRestModel Api(ApiHeadersModel headers)
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
