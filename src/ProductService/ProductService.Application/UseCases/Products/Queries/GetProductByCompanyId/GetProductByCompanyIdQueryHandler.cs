using MediatR;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetProductByCompanyId;

#pragma warning disable

public class GetProductByCompanyIdQueryHandler : IRequestHandler<GetProductByCompanyIdQuery, IQueryable<Product>>
{
    private readonly IAppDbContext _context;

    public GetProductByCompanyIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Product>> Handle(GetProductByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        return _context.Products.Where(x => x.CompanyId == request.CompanyId);
    }
}
