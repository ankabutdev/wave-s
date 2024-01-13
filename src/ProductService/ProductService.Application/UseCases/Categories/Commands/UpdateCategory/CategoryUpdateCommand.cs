using MediatR;

namespace ProductService.Application.UseCases.Categories.Commands.UpdateCategory;

public class CategoryUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; }
}
