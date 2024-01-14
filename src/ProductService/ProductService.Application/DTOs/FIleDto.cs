using Microsoft.AspNetCore.Http;

namespace ProductService.Application.DTOs
{
    public class FIleDto
    {
        public List<IFormFile> ImagePaths { get; set; } = default!;
    }
}
