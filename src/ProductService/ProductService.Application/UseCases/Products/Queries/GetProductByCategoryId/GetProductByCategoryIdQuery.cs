using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetProductByCategoryId;

public class GetProductByCategoryIdQuery : IRequest<IQueryable<Product>>
{
    public int CategoryId { get; set; }
}