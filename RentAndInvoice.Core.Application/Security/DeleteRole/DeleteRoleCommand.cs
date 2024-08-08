using MediatR;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.DeleteRole;

public record DeleteRoleCommand(RoleId RoleId) : IRequest;