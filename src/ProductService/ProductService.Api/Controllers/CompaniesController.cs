using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs.Companies;
using ProductService.Application.UseCases.Companies.Commands.CreateCompany;
using ProductService.Application.UseCases.Companies.Commands.DeleteCompany;
using ProductService.Application.UseCases.Companies.Commands.UpdateCompany;
using ProductService.Application.UseCases.Companies.Queries.GetAllCompany;
using ProductService.Application.UseCases.Companies.Queries.GetByIdCompany;

namespace ProductService.Api.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CompaniesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllCompanyQuery()));
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
