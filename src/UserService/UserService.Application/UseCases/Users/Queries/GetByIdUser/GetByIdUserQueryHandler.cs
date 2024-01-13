using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Abstractions;
using UserService.Domain.Entities.Users;

namespace UserService.Application.UseCases.Users.Queries.GetByIdUser;

public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, User>
{
    private readonly IAppDbContext _context;

    public GetByIdUserQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("User not found!");
    }
}
