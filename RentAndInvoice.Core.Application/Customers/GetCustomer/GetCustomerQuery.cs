using MediatR;
using RentAndInvoice.Core.Domain.Entities.Customers;

namespace RentAndInvoice.Core.Application.Customers.GetCustomer;

public record GetCustomerQuery(CustomerId CustomerId) : IRequest<CustomerResponse>;

public record CustomerResponse(
    Guid Id,

    string Name,

    string Email
    
    );
