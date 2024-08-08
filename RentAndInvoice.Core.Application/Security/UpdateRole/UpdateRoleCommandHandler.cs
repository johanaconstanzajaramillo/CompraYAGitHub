using MediatR;
using RentAndInvoice.Core.Application.Security.UpdatePage;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.UpdateRole;

public sealed class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    IRoleRepository _roleRepository;
    IPageRepository _pageRepository;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository, IPageRepository pageRepository)
    {
        _roleRepository = roleRepository;
        _pageRepository = pageRepository;
    }

    public Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        var role = _roleRepository.GetByIdAsync(request.Id);

        if (role is null)
        {
            throw new RoleNotFoundException(request.Id);
        }


        var pages = request.Pages.ToEntities(_pageRepository);

        role.Update(
            request.Name,
            request.Priority,
            pages);

        _roleRepository.Update(role);
        return Task.CompletedTask;
    }
   
}
