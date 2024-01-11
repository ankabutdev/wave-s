using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;

namespace ProductService.Application.UseCases.Products.Commands.DeleteProduct;

public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public ProductDeleteCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

        _context.Products.Remove(products);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
