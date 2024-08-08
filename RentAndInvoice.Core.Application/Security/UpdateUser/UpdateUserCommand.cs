using MediatR;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.UpdateUser;

public record UpdateUserCommand(UserId Id, string FirstName, string LastName, string Password, string Email, List<Role> Roles, bool Enabled) : IRequest;


public record UpdateUserRequest(
    string FirstName, string LastName, string Password, string Email, List<Role> Roles, bool Enabled
    ) : IRequest;