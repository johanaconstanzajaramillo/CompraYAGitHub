using MediatR;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.DeleteUser;

public record DeleteUserCommand(UserId UserId) : IRequest;