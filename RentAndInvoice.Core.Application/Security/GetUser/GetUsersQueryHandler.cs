using MediatR;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Application.Security.GetRole;

namespace RentAndInvoice.Core.Application.Security.GetUser;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetUsersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _context
           .Users
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
               u.Enabled)).ToList();

        return Task.FromResult(users);
    }
}
