using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;

namespace ProductService.Application.UseCases.Categories.Commands.UpdateCategory;

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryUpdateCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (categories is null)
                throw new ArgumentNullException(nameof(categories));

            _mapper.Map(request, categories);

            categories.UpdatedAt = DateTime.UtcNow;

            _context.Categories.Update(categories);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
