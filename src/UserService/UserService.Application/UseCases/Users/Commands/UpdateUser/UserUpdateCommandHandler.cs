using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Abstractions;

namespace UserService.Application.UseCases.Orders.Commands.UpdateUser;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UserUpdateCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (categories is null)
                throw new ArgumentNullException(nameof(categories));

            _mapper.Map(request, categories);

            categories.UpdatedAt = DateTime.UtcNow;

            _context.Users.Update(categories);

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
