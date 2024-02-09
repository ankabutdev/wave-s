using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;

namespace ProductService.Application.UseCases.Products.Queries.GetProductCount;

public class GetProudctCountQueryHandler : IRequestHandler<GetProudctCountQuery, long>
{
    private readonly IAppDbContext _context;

    public GetProudctCountQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(GetProudctCountQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .LongCountAsync(cancellationToken);
    }
}
