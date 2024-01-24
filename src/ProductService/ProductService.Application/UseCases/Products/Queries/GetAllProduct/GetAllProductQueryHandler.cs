using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
{
    private readonly IAppDbContext _context;

    public GetAllProductQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Products
            .AsNoTracking()
            .ToListAsync();
        //.Include(x => x.Category)
        //.ThenInclude(y => y.Products)
        //.ToListAsync(cancellationToken);
    }
}
