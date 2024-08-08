using MediatR;
using RentAndInvoice.Core.Application.Security.DeleteRole;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.DeleteUser;

internal sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var role = _userRepository.GetByIdAsync(request.UserId);

        if (role is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        _userRepository.Remove(role);

        return Task.CompletedTask;
    }
}
