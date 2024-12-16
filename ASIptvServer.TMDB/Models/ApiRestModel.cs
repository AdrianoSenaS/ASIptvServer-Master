using RestSharp;


namespace ASIptvServer.TMDB.Models
{
    public class ApiRestModel
    {
        public RestClient restClient { get; set; }
        public RestRequest restRequest { get; set; }
    }
}
