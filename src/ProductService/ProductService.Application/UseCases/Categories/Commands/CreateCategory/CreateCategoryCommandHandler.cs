using AutoMapper;
using MediatR;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Category>(request);

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.Categories.AddAsync(entity, cancellationToken);

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
