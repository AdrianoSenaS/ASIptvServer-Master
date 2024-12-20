using Microsoft.AspNetCore.Http;
namespace ASIptvServer.Api.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadFile(IFormFile formFile);
    }
}
