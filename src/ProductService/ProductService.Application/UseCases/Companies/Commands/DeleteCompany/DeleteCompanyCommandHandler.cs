using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;

namespace ProductService.Application.UseCases.Companies.Commands.DeleteCompany;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public DeleteCompanyCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var companies = await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken);

        if (companies is null)
            return false;

        _context.Companies.Remove(companies);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
