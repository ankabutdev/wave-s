using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProductService.Application.DTOs.Categories;
using ProductService.Application.UseCases.Categories.Commands.CreateCategory;
using ProductService.Application.UseCases.Categories.Commands.DeleteCategory;
using ProductService.Application.UseCases.Categories.Commands.UpdateCategory;
using ProductService.Application.UseCases.Categories.Queries.GetAllCategory;
using ProductService.Application.UseCases.Categories.Queries.GetByIdCategory;
using ProductService.Domain.Entities;

namespace ProductService.Api.Controllers;

#pragma warning disable

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;


    public CategoriesController(IMediator mediator, IMapper mapper,
        IMemoryCache cache)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        // Console.WriteLine(HttpContext.Request.Host.Value);

        if (_cache.TryGetValue("AllCategories", out var cachedData))
        {
            IEnumerable<Category>? data = (IEnumerable<Category>)cachedData;
            Console.WriteLine("GET DATA CACHE MEMORY");
            return Ok(data);
        }

        var result = await _mediator.Send(new GetAllCategoryQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllCategories", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        var result = await _mediator
            .Send(new GetByIdCategoryQuery { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(CategoryCreateDto dto)
    {
        var category = _mapper.Map<CreateCategoryCommand>(dto);

        var result = await _mediator.Send(category);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(int Id, CategoryUpdateDto dto)
    {
        var category = _mapper.Map<CategoryUpdateCommand>(dto);

        category.Id = Id;

        var result = await _mediator.Send(category);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var result = await _mediator
            .Send(new CategoryDeleteCommand() { Id = Id });

        return Ok(result);
    }
}
