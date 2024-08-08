using MediatR;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Application.Security.GetRole;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.GetUser;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IApplicationDbContext _context;

    public GetUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = _context
           .Users
           .Where(r => r.Id == request.UserId)
           .Select(u => new UserResponse(
               u.Id.Value,
               u.FirstName,
               u.LastName,
               u.Password,
               u.Email,
                 u.Roles.Select(p => new RoleResponse(
                    p.Id.Value,
                    p.Name,
                    p.Priority,
                    null))
                .ToList(),
                 u.Enabled))
           .FirstOrDefault();

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        return Task.FromResult(user);
    }
}
