using MediatR;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetProductByCategoryId;

#pragma warning disable

public class GetProductByCategoryIdQueryHandler : IRequestHandler<GetProductByCategoryIdQuery, IQueryable<Product>>
{
    private readonly IAppDbContext _context;

    public GetProductByCategoryIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Product>> Handle(GetProductByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        return _context.Products
            .Where(x => x.CategoryId == request.CategoryId)
            .Skip(request.@params
            .GetSkipCount())
            .Take(request
            .@params.PageSize);
    }
}
