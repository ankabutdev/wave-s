using MediatR;
using UserService.Domain.Entities.Users;

namespace UserService.Application.UseCases.Users.Queries.GetAllUser;

public class GetAllUserQuery : IRequest<IEnumerable<User>>
{
}
