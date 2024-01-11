using AutoMapper;
using MediatR;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Companies.Commands.CreateCompany;

public class CompanyCreateCommandHandler : IRequestHandler<CompanyCreateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CompanyCreateCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Company>(request);

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.Companies.AddAsync(entity, cancellationToken);

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
