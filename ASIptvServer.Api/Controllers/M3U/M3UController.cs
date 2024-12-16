using ASIptvServer.Api.Interfaces;
using ASIptvServer.Api.Models;
using ASIptvServer.System.Configuration;
using ASIptvServer.IO;
using ASIptvServer.IO.FilesServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ASIptvServer.Api.Controllers.M3U
{
    [Route("api/[controller]")]
    [ApiController]
    public class M3UController
    {
        private readonly IM3uService _m3uService;
        private readonly IVerification _verification;
        public M3UController(IM3uService m3UService, IVerification verification)
        {
            _m3uService = m3UService;
            _verification = verification;
        }

        [HttpPost("FileM3u")]
        [RequestSizeLimit(1024 * 1024 * 1024)] // 1 GB
        public async Task<ActionResult<string>> FileM3u(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "Nenhum arquivo selecionado";
            var uploadPath = Path.Combine(_verification.Verification().PathTempData);
            path path = new path(uploadPath);
            Folder.CreateFolder(path);
            var filepath = Path.Combine(uploadPath, file.FileName);
            try
            {
                using(var stream = new FileStream(filepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                Task.Run(()=> _m3uService.UpdateM3uPath(filepath));
                return "Lista Enviada" + (new { FilePath = filepath }   );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("UrlM3u")]
        public async Task<ActionResult<string>> UrlM3u(string url)
        {
            Task.Run(()=>_m3uService.UpdateM3uUrl(url));
            return "Lista Atualizada";
        }
    }
}
