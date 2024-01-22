using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProductService.Application.DTOs.Companies;
using ProductService.Application.UseCases.Companies.Commands.CreateCompany;
using ProductService.Application.UseCases.Companies.Commands.DeleteCompany;
using ProductService.Application.UseCases.Companies.Commands.UpdateCompany;
using ProductService.Application.UseCases.Companies.Queries.GetAllCompany;
using ProductService.Application.UseCases.Companies.Queries.GetByIdCompany;
using ProductService.Domain.Entities;

namespace ProductService.Api.Controllers;

#pragma warning disable

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public CompaniesController(IMediator mediator, IMapper mapper,
        IMemoryCache cache)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllCompanies", out var cachedData))
        {
            IEnumerable<Company>? data = (IEnumerable<Company>)cachedData;
            Console.WriteLine("GET DATA CACHE MEMORY");
            return Ok(data);
        }

        var result = await _mediator.Send(new GetAllCompanyQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllCompanies", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        var result = await _mediator
            .Send(new GetByIdCompanyQuery { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(CompanyCreateDto dto)
    {
        var company = _mapper.Map<CompanyCreateCommand>(dto);

        var result = await _mediator.Send(company);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(int Id, CompanyUpdateDto dto)
    {
        var company = _mapper.Map<CompanyUpdateCommand>(dto);
        company.Id = Id;
        var result = await _mediator.Send(company);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var result = await _mediator
            .Send(new DeleteCompanyCommand() { Id = Id });

        return Ok(result);
    }
}
