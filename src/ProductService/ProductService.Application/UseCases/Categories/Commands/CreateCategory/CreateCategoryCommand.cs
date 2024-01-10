using MediatR;

namespace ProductService.Application.UseCases.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<bool>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
