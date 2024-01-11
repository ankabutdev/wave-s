using MediatR;

namespace ProductService.Application.UseCases.Products.Commands.DeleteProduct;

public class ProductDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
