using MediatR;
using RentAndInvoice.Core.Application.Security.UpdatePage;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.CreateRole;

public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
{
    IRoleRepository _roleRepository;
    IPageRepository _pageRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository, IPageRepository pageRepository)
    {
        _roleRepository = roleRepository;
        _pageRepository = pageRepository;
    }

    public Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        var roles = _roleRepository.GetAll();

        var id = roles.Any() ? roles.Max(r => r.Id.Value) + 1 : 1;

        var pages = request.Pages.ToEntities(_pageRepository);

        var role = new Role(
            new RoleId((byte)id),
            request.Name,
            request.Priority,
            pages
            );

        _roleRepository.Add(role);
        return Task.CompletedTask;
    }
}
