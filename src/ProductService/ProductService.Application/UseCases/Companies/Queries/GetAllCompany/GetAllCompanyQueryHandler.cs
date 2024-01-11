using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Companies.Queries.GetAllCompany;

public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, IEnumerable<Company>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCompanyQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Company>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Companies
            .ToListAsync(cancellationToken);
    }
}
