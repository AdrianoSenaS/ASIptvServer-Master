using ASIptvServer.Api.Interfaces;
using ASIptvServer.IO;
using ASIptvServer.IO.FilesServer;
using ASIptvServer.System.Configuration;
using Microsoft.AspNetCore.Http;

namespace ASIptvServer.Api.Services.IO
{
    public class UploadService : IUploadService
    {
        private readonly IVerification _verification;
        public UploadService(IVerification verification)
        {
            _verification = verification;
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "Nenhum arquivo selecionado";
            var uploadPath = Path.Combine(_verification.Verification().PathTempData);
            path path = new path(uploadPath);
            Folder.CreateFolder(path);
            var filepath = Path.Combine(uploadPath, file.FileName);
            try
            {
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filepath;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
