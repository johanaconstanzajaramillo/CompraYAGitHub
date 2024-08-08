using MediatR;

namespace RentAndInvoice.Core.Application.Security.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;