using MediatR;
using ProductService.Application.Common.Utils;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Queries.GetAllProduct;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
    public PaginationParams @params { get; set; } = default!;
}
