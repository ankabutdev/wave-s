using MediatR;
using UserService.Domain.Entities.Users;

namespace UserService.Application.UseCases.Users.Queries.GetByIdUser;

public class GetByIdUserQuery : IRequest<User>
{
    public int Id { get; set; }
}
