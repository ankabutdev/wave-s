using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Abstractions;
using UserService.Domain.Entities.Users;

namespace UserService.Application.UseCases.Users.Queries.GetAllUser;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
{
    private readonly IAppDbContext _context;

    public GetAllUserQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Users
            //.Include(x => x.Products)
            .ToListAsync(cancellationToken);
    }
}
