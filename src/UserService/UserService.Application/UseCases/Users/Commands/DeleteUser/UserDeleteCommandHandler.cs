using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Abstractions;

namespace UserService.Application.UseCases.Orders.Commands.DeleteUser;

public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, bool>
{
    private readonly IAppDbContext _context;

    public UserDeleteCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<bool> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var categories = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (categories == null)
            return false;

        _context.Users.Remove(categories);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
