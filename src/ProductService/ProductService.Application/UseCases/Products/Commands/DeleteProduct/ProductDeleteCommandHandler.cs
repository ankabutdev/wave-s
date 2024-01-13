using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Application.Interfaces.Files;

namespace ProductService.Application.UseCases.Products.Commands.DeleteProduct;

public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public ProductDeleteCommandHandler(IAppDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<bool> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var products = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken);

        if (products is null)
            return false;

        var imageResult = await _fileService
            .DeleteImageAsync(products.ImagePaths);

        if (imageResult == false)
            throw new Exception("Image fot found!");

        _context.Products.Remove(products);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
