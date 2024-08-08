using MediatR;
using RentAndInvoice.Core.Domain.Entities.Customers;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Products.DeleteCategory;

internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository categoryRepository)
    {
        _customerRepository = categoryRepository;
    }

    public Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _customerRepository.GetByIdAsync(request.CustomerId);

        if (customer is null)
        {
            throw new CustomerNotFoundException(customer.Id);
        }

        _customerRepository.Remove(customer);

        return Task.CompletedTask;
    }
}
