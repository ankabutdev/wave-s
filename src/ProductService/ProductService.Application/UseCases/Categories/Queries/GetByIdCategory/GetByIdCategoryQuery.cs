using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQuery : IRequest<Category>
{
    public int Id { get; set; }
}
