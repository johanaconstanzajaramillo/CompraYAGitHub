using MediatR;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Application.Security.GetPage;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.GetRole;

internal sealed class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleResponse>
{
    private readonly IApplicationDbContext _context;

    public GetRoleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<RoleResponse> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var role = _context
           .Roles
           .Where(r=>r.Id==request.RoleId)
           .Select(p => new RoleResponse(
               p.Id.Value,
               p.Name,
               p.Priority,
               p.Pages.Select(pa=> new PageResponse(pa.Id.Value,pa.Name,pa.Url,pa.Enabled)).ToList()))
           .FirstOrDefault();

        if (role is null)
        {
            throw new RoleNotFoundException(request.RoleId);
        }

        return Task.FromResult(role);
    }
}
