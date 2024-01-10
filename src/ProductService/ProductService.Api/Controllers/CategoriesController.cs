using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs.Categories;
using ProductService.Application.UseCases.Categories.Commands.CreateCategory;
using ProductService.Application.UseCases.Categories.Queries.GetAllCategory;

namespace ProductService.Api.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllCategoryQuery()));
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(CategoryCreateDto dto)
    {
        var category = _mapper.Map<CreateCategoryCommand>(dto);

        var result = await _mediator.Send(category);

        return Ok(result);
    }
}
