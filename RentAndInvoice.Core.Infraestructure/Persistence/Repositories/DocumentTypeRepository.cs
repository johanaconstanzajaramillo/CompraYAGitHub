
using RentAndInvoice.Core.Domain.Entities.General;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

internal sealed class DocumentTypeRepository : IDocumentTypeRepository
{
    private readonly ApplicationDbContext _context;

    public DocumentTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public DocumentType GetByIdAsync(DocumentTypeId id)
    {
        return _context.DocumentTypes
            .FirstOrDefault(p => p.Id == id);
    }
}
