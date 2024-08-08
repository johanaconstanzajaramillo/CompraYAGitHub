using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

internal sealed class PageRepository : IPageRepository
{
    private readonly ApplicationDbContext _context;

    public PageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Page GetByIdAsync(PageId id)
    {
        return _context.Pages
            .FirstOrDefault(p => p.Id == id);
    }

    public void Update(Page page)
    {
        _context.Pages.Update(page);
        _context.SaveChanges();
    }
}
