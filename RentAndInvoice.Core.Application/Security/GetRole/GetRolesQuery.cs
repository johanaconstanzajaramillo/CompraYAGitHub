using MediatR;

namespace RentAndInvoice.Core.Application.Security.GetRole;

public sealed record GetRolesQuery : IRequest<List<RoleResponse>>;