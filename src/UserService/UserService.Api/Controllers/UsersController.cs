using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using UserService.Application.DTOs.Users;
using UserService.Application.UseCases.Orders.Commands.CreateUser;
using UserService.Application.UseCases.Orders.Commands.DeleteUser;
using UserService.Application.UseCases.Orders.Commands.UpdateUser;
using UserService.Application.UseCases.Users.Queries.GetAllUser;
using UserService.Application.UseCases.Users.Queries.GetByIdUser;
using UserService.Domain.Entities.Users;

namespace UserService.Api.Controllers;

#pragma warning disable 

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public UsersController(IMediator mediator, IMapper mapper,
        IMemoryCache cache)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllUsers", out var cachedData))
        {
            IEnumerable<User>? user = (IEnumerable<User>)cachedData;
            Console.WriteLine("GET DATA CACHE MEMORY");
            return Ok(user);
        }

        var result = await _mediator.Send(new GetAllUserQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllUsers", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        var result = await _mediator
            .Send(new GetByIdUserQuery { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(UserCreateDto dto)
    {
        var category = _mapper.Map<CreateUserCommand>(dto);

        var result = await _mediator.Send(category);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(int Id, UserUpdateDto dto)
    {
        var category = _mapper.Map<UserUpdateCommand>(dto);
        category.Id = Id;
        var result = await _mediator.Send(category);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var result = await _mediator
            .Send(new UserDeleteCommand() { Id = Id });

        return Ok(result);
    }
}
