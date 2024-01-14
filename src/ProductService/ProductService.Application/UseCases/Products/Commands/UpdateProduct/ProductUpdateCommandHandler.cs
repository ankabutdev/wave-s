using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Application.Interfaces.Files;
using ProductService.Domain.Entities;
using System.Text;

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
            var products = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (products is null)
                throw new ArgumentNullException(nameof(products));

            if (request.ImagePaths is not null)
            {
                await DeleteImages(products);

                products.ImagePaths = await UplaodImages(request);
            }

            _mapper.Map(request, products);

            products.UpdatedAt = DateTime.UtcNow;

            _context.Products.Update(products);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }

    private async Task DeleteImages(Product products)
    {
        foreach (var image in products.ImagePaths.Split("&"))
        {
            await _fileService.DeleteImageAsync(image);
        }
    }

    private async Task<string> UplaodImages(ProductUpdateCommand products)
    {
        var imagePaths = new StringBuilder();

        foreach (var image in products.ImagePaths!)
        {
            string imagePath = await _fileService.UploadImageAsync(image);
            imagePaths.Append(imagePath + "&");
        }

        return imagePaths.ToString();
    }
}
