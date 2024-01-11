using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetByIdProduct;

public class GetByIdProductQuery : IRequest<Product>
{
    public int Id { get; set; }
}
