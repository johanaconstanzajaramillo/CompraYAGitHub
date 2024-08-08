namespace RentAndInvoice.Core.Domain.Entities.Security;

public sealed class PageNotFoundException : Exception
{

	public PageNotFoundException(PageId id): base($"The page with the ID = {id.Value} was not found")
	{

	}
}
