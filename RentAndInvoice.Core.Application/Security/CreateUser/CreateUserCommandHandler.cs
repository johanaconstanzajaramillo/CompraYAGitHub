using MediatR;
using RentAndInvoice.Core.Application.Security.UpdateRole;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    IUserRepository _userRepository;
    IRoleRepository _roleRepository;

    public CreateUserCommandHandler(IUserRepository userRepository,IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
    }

    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        var users = _userRepository.GetAll();

        var id = users.Any() ? users.Max(r => r.Id.Value) + 1 : 1;

        List<Role> roles = request.Roles.ToEntities(_roleRepository);

        var user = new User(
            new UserId(id),
            request.FirstName,
            request.LastName,
            request.Password,
            request.Email,
            roles,
            request.Enabled
            );

        _userRepository.Add(user);
        return Task.CompletedTask;
    }
}
