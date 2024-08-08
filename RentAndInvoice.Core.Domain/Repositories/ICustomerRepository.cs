using RentAndInvoice.Core.Domain.Entities.Customers;

namespace RentAndInvoice.Core.Domain.Repositories;

public interface ICustomerRepository
{
    Customer GetByIdAsync(CustomerId id);

    void Add(Customer Customer);

    void Update(Customer Customer);

    void Remove(Customer Customer);
}
