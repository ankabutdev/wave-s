using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;

namespace ProductService.Application.UseCases.Companies.Commands.UpdateCompany;

public class CompanyUpdateCommandHandler : IRequestHandler<CompanyUpdateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CompanyUpdateCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CompanyUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var companies = await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (companies is null)
                throw new ArgumentNullException(nameof(companies));

            _mapper.Map(request, companies);

            companies.UpdatedAt = DateTime.UtcNow;

            _context.Companies.Update(companies);

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
