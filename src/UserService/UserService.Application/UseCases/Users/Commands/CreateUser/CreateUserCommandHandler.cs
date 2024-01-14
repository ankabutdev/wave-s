using AutoMapper;
using MediatR;
using UserService.Application.Abstractions;
using UserService.Domain.Entities.Users;

namespace UserService.Application.UseCases.Orders.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<User>(request);

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.Users.AddAsync(entity, cancellationToken);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
