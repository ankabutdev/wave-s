using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetByIdProduct;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, Product>
{
    private readonly IAppDbContext _context;

    public GetByIdProductQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Product not found!");
    }
}
