using MediatR;
using RentAndInvoice.Core.Application.Security.GetPage;
using RentAndInvoice.Core.Application.Security.UpdatePage;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.UpdateRole;

public record UpdateRoleCommand(RoleId Id, string Name, byte Priority, List<PageRequest> Pages) :IRequest;

public record UpdateRoleRequest(string Name, byte Priority, List<GetPage.PageRequest> Pages) :IRequest;