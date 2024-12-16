using ASIptvServer.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ASIptvServer.Api.Controllers.M3U
{
    [Route("api/[controller]")]
    [ApiController]
    public class M3UController
    {
        private readonly IM3uService _m3uService;
        private readonly IUploadService _uploadService;
        public M3UController(IM3uService m3UService, IUploadService uploadService)
        {
            _m3uService = m3UService;
            _uploadService = uploadService;
        }
        [HttpPost("FileM3u")]
        [RequestSizeLimit(1024 * 1024 * 1024)] // 1 GB
        public ActionResult<string> FileM3u(IFormFile file)
        {
            var result =  _uploadService.UploadFile(file);
            if (result.Result != "Nenhum arquivo selecionado")
            {
                Task.Run(() =>  _m3uService.UpdateM3uPath(result.Result));
                return result.Result;
            }
            else
            {
                return "Nenhum arquivo selecionado";
            }
        }
        [HttpPost("UrlM3u")]
        public ActionResult<string> UrlM3u(string url)
        {
            Task.Run(()=>_m3uService.UpdateM3uUrl(url));
            return "Lista Atualizada";
        }
    }
}
