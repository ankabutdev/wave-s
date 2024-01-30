using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetProductByCategoryName;

public class GetProductByCategoryNameQuery : IRequest<IQueryable<Product>>
{
    public string CategoryName { get; set; } = string.Empty;
}
