using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, Category>
{
    private readonly IAppDbContext _context;

    public GetByIdCategoryQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Category> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Category not found!");
    }
}
