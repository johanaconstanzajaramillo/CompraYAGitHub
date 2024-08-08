using MediatR;
using RentAndInvoice.Core.Application.Security.GetRole;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.GetUser;

public record GetUserQuery(UserId UserId) : IRequest<UserResponse>;

public record UserResponse(
    int Id,
    string FirstName,
    string LastName,
    string Password,
    string Email,
    List<RoleResponse> Roles,
    bool Enabled
    );
