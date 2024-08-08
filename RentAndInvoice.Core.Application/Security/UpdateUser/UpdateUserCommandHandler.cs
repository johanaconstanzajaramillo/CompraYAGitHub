using MediatR;
using RentAndInvoice.Core.Application.Security.CreateUser;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.UpdateUser;

public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        var user = _userRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new UserNotFoundException(request.Id);
        }

        user.Update(
            request.FirstName,
            request.LastName,
            request.Password,
            request.Email,
            request.Roles,
            request.Enabled);

        _userRepository.Update(user);
        return Task.CompletedTask;
    }
}
