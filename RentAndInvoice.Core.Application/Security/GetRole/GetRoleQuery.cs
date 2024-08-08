using MediatR;
using RentAndInvoice.Core.Application.Security.GetPage;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.GetRole;

public record GetRoleQuery(RoleId RoleId) : IRequest<RoleResponse>;

public record RoleResponse(
    byte Id,
    string Name,
    byte Priority,
    List<PageResponse> Pages
    );
