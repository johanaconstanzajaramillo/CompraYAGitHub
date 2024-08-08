using MediatR;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Application.Security.GetPage;

namespace RentAndInvoice.Core.Application.Security.GetRole;

internal sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetRolesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<List<RoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = _context
           .Roles
           .Select(p => new RoleResponse(
               p.Id.Value,
               p.Name,
               p.Priority,
               p.Pages.Select(pa => new PageResponse(pa.Id.Value, pa.Name, pa.Url, pa.Enabled)).ToList()))
           .ToList();

        return Task.FromResult(roles);
    }
}
