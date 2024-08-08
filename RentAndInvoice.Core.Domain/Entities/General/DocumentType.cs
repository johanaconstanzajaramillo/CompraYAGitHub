namespace RentAndInvoice.Core.Domain.Entities.General;

public class DocumentType
{
    public DocumentType(string name, DocumentTypeId id)
    {
        Name = name;
        Id = id;
    }

    private DocumentType()
	{

	}

    public string Name { get; set; } = string.Empty;

	public DocumentTypeId Id { get; set; }

    public void Update(string name, DocumentTypeId id)
    {
        Name = name;
        Id = id;
    }

}
