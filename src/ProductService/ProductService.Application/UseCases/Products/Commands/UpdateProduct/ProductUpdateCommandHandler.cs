using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Application.Interfaces.Files;

namespace ProductService.Application.UseCases.Products.Commands.UpdateProduct;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public ProductUpdateCommandHandler(IAppDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<bool> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product is null)
                throw new Exception("Product Not Found");

            if (request.ImagePath is not null)
            {
                var deleteImage = await _fileService.DeleteImageAsync(product.ImagePath);
                if (deleteImage)
                {
                    string newImagePath = await _fileService.UploadImageAsync(request.ImagePath);

                    product.ImagePath = newImagePath;
                }
                else
                    throw new Exception("Image not Found");
            }

            _mapper.Map(request, product);

            product.UpdatedAt = DateTime.UtcNow;

            _context.Products.Update(product);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }

    //private async Task DeleteImages(Product products)
    //{
    //    foreach (var image in products.ImagePaths.Split("&"))
    //    {
    //        await _fileService.DeleteImageAsync(image);
    //    }
    //}

    //private async Task<string> UplaodImages(ProductUpdateCommand products)
    //{
    //    var imagePaths = new StringBuilder();

    //    foreach (var image in products.ImagePaths!)
    //    {
    //        string imagePath = await _fileService.UploadImageAsync(image);
    //        imagePaths.Append(imagePath + "&");
    //    }

    //    return imagePaths.ToString();
    //}
}
