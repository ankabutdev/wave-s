using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetProductByCompanyId;

public class GetProductByCompanyIdQuery : IRequest<IQueryable<Product>>
{
    public int CompanyId { get; set; }
}
