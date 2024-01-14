using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Application.Interfaces.Files;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Commands.DeleteProduct;

public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IFileService _fileService;

    public ProductDeleteCommandHandler(IAppDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<bool> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        // Get Product
        var products = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken);

        // Check product is not null
        if (products is null)
            return false;

        // Deleted Images
        await RemoveImages(products);

        // Delete Product
        _context.Products.Remove(products);

        // Save
        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    private async Task RemoveImages(Product products)
    {
        var countResult = 0;

        foreach (var path in products.ImagePaths.Split("&"))
        {
            await _fileService.DeleteImageAsync(path);
            countResult++;
        }

        if (countResult < 1)
            throw new Exception("Image fot found!");
    }
}
