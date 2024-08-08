using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Domain.Repositories;

public interface IPageRepository
{
    Page GetByIdAsync(PageId id);
    void Update(Page page);
}
