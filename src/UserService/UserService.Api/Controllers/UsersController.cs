using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs.Users;
using UserService.Application.UseCases.Orders.Commands.CreateUser;
using UserService.Application.UseCases.Orders.Commands.DeleteUser;
using UserService.Application.UseCases.Orders.Commands.UpdateUser;
using UserService.Application.UseCases.Users.Queries.GetAllUser;
using UserService.Application.UseCases.Users.Queries.GetByIdUser;

namespace UserService.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllUserQuery()));
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
