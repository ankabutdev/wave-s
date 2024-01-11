using MediatR;

namespace ProductService.Application.UseCases.Categories.Commands.DeleteCategory;

public class CategoryDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
