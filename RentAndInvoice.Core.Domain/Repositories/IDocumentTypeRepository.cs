using RentAndInvoice.Core.Domain.Entities.General;

namespace RentAndInvoice.Core.Domain.Repositories;

public interface IDocumentTypeRepository
{
    DocumentType GetByIdAsync(DocumentTypeId id);
}
