using MediatR;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.DeleteRole;

internal sealed class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _roleRepository.GetByIdAsync(request.RoleId);

        if (role is null)
        {
            throw new RoleNotFoundException(request.RoleId);
        }

        _roleRepository.Remove(role);

        return Task.CompletedTask;
    }
}
