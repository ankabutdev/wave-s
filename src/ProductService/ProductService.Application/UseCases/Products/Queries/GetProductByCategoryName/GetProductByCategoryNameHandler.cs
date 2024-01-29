using MediatR;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetProductByCategoryName;

#pragma warning disable

public class GetProductByCategoryNameHandler : IRequestHandler<GetProductByCategoryNameQuery, IQueryable<Product>>
{

    private readonly IAppDbContext _context;

    public GetProductByCategoryNameHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Product>> Handle(GetProductByCategoryNameQuery request, CancellationToken cancellationToken)
    {
        return _context
            .Products
            .Where(x => x.Category.Name
            .Contains(request.CategoryName));
    }
}
