using RestSharp;


namespace ASIptvServer.TMDB
{
    public class ApiRest
    {
        public RestClient restClient { get; set; }
        public RestRequest restRequest { get; set; }
    }
}
