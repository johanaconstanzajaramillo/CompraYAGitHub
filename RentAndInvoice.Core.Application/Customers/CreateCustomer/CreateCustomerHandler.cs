using MediatR;
using RentAndInvoice.Core.Domain.Entities.Customers;
using RentAndInvoice.Core.Domain.Entities.General;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Customers.CreateCustomer;

public sealed class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDocumentTypeRepository _documentTypeRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IDocumentTypeRepository documentTypeRepository)
    {
        _customerRepository = customerRepository;
        _documentTypeRepository = documentTypeRepository;
    }

    public Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        DocumentType documentType = _documentTypeRepository.GetByIdAsync(new DocumentTypeId(request.documentTypeId));

        if (documentType is null)
        {
            throw new DocumentTypeNotFoundException(new DocumentTypeId(request.documentTypeId));
        }


        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            documentType,
            request.documentNumber,
            request.name,
            request.email,
            request.phones.Select(p => new Phone(new PhoneId(Guid.NewGuid()) ,p )).ToList(),
            request.addresses.Select(a => new Address(a,new AddressId(Guid.NewGuid()))).ToList(),
            (CustomerType)request.customerType); 

        _customerRepository.Add(customer);
        return Task.CompletedTask;
    }
}