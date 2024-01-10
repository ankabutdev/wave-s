
using Microsoft.AspNetCore.Http;

namespace ProductService.Application.Interfaces.Files;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);
}
