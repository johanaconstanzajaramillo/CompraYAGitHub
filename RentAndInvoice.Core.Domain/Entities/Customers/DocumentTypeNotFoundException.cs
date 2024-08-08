using RentAndInvoice.Core.Domain.Entities.General;

namespace RentAndInvoice.Core.Domain.Entities.Customers;

public sealed class DocumentTypeNotFoundException : Exception
{

	public DocumentTypeNotFoundException(DocumentTypeId id): base($"The DocumentType with the ID = {id.Value} was not found")
	{

	}
}
