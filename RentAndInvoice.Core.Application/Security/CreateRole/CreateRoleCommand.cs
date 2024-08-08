using MediatR;
using RentAndInvoice.Core.Application.Security.GetPage;

namespace RentAndInvoice.Core.Application.Security.CreateRole;

public record CreateRoleCommand(string Name, byte Priority, List<PageRequest> Pages) :IRequest;