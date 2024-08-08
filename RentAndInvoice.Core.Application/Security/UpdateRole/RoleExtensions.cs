using RentAndInvoice.Core.Application.Security.CreateUser;
using RentAndInvoice.Core.Application.Security.GetRole;
using RentAndInvoice.Core.Application.Security.UpdatePage;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.UpdateRole;

public static class RoleExtensions
{
    public static Role ToEntity(this RoleRequest roleCommand, IRoleRepository roleRepository)
    {
        var eFRole = roleRepository.GetByIdAsync(new RoleId(roleCommand.id));

        if (eFRole is null)
        {
            throw new RoleNotFoundException(new RoleId(roleCommand.id));
        }

        return eFRole;
    }

    public static List<Role> ToEntities(this IEnumerable<RoleRequest> roleCommands, IRoleRepository roleRepository)
    {
        var roles = new List<Role>();

        foreach (var roleCommand in roleCommands)
        {
            var eFRole = roleCommand.ToEntity(roleRepository);
            roles.Add(eFRole);
        }

        return roles;
    }

    //public static List<RoleResponse> ToEntities(this IEnumerable<Role> roles, IRoleRepository roleRepository)
    //{
    //    var roleResponses = new List<RoleResponse>();

    //    foreach (var role in roles)
    //    {
    //        var roleResponse = role.ToEntity(roleRepository);
    //        roleResponses.Add(roleResponse);
    //    }

    //    return roleResponses;
    //}

    public static RoleResponse ToEntity(this Role role, IRoleRepository roleRepository, IPageRepository pageRepository)
    {
        var roleResponse = roleRepository.GetByIdAsync(role.Id);

        if (roleResponse is null)
        {
            throw new RoleNotFoundException(role.Id);
        }

        return new RoleResponse(roleResponse.Id.Value, roleResponse.Name, roleResponse.Priority,roleResponse.Pages.ToEntities(pageRepository));
    }
}
