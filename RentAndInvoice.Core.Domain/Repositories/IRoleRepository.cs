using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Domain.Repositories;

public interface IRoleRepository
{
    Role GetByIdAsync(RoleId id);
    List<Role> GetAll();

    void Add(Role role);

    void Update(Role role);

    void Remove(Role role);
}
