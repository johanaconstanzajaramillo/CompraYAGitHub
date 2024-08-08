using MediatR;

namespace RentAndInvoice.Core.Application.Security.GetUser;

public sealed record GetUsersQuery : IRequest<List<UserResponse>>;