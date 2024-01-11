using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetAllProduct;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
}
