using MediatR;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.CreateUser;

public record CreateUserCommand(string FirstName, string LastName, string Password, string Email, List<RoleRequest> Roles, bool Enabled) :IRequest;


public record RoleRequest(
    byte id
    ) : IRequest;