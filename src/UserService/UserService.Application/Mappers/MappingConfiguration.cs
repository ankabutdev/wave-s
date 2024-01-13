using AutoMapper;
using UserService.Application.DTOs.Users;
using UserService.Application.UseCases.Orders.Commands.CreateUser;
using UserService.Application.UseCases.Orders.Commands.UpdateUser;
using UserService.Domain.Entities.Users;

namespace UserService.Application.Mappers;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        // Users
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();

        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UserUpdateCommand>().ReverseMap();

        CreateMap<UserCreateDto, CreateUserCommand>().ReverseMap();
        CreateMap<UserUpdateDto, UserUpdateCommand>().ReverseMap();
    }
}
