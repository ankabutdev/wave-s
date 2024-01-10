using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Categories.Queries.GetAllCategory;

public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
{
}
