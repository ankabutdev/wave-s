using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Companies.Queries.GetByIdCompany;

public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, Company>
{
    private readonly IAppDbContext _context;
    
    public GetByIdCompanyQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Company> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Company not found!");
    }
}
