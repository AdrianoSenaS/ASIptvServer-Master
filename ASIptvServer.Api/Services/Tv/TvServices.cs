using ASIptvServer.Api.Interfaces;
using ASIptvServer.Api.Models;
using ASIptvServer.System.Configuration;
using Microsoft.Extensions.Logging;

namespace ASIptvServer.Api.Services.Tv
{
    public interface ITvServices
    {
        void TV(M3U.M3U item);
    }
    public class TvServices: ITvServices
    {
        private readonly ITvService _tvService;
        private readonly IVerification _verification;
        public TvServices(ITvService tvService, IVerification verification)
        {
            _tvService = tvService;
            _verification = verification;
        }
        public void TV(M3U.M3U item)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddProvider(new FileLoggerProvider(_verification.Verification().PathTemp + "TV.log"));
            });
            ILogger logger = loggerFactory.CreateLogger("Tv M3U");
            TvModel tv = new TvModel();
            CategoriesModel categories = new CategoriesModel();
            tv.Id = item.Id;
            tv.Title = item.Name;
            tv.Logo = item.Logo;
            tv.Categories = item.Categories;
            tv.Url = item.Url;
            _tvService.SetTv(tv);
            categories.Category = item.Categories;
            _tvService.SetCategoryTv(categories);
           logger.LogInformation("Adicionando: " + item.Name);
        }
    }
}
