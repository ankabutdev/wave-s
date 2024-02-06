using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetAllProduct;

#pragma warning disable

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
{
    private readonly IAppDbContext _context;

    public GetAllProductQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        //return await _context
        //    .Products
        //    .AsNoTracking()
        //    .ToListAsync();

        return await _context.Products
            .Skip(request.@params.GetSkipCount())
            .Take(request.@params.PageSize)
            .ToListAsync(cancellationToken);

    }
}
