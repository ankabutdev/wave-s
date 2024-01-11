using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;

namespace ProductService.Application.UseCases.Categories.Commands.DeleteCategory;

public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryDeleteCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var categories = await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (categories == null)
            return false;

        _context.Categories.Remove(categories);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
