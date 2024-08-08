using MediatR;

namespace RentAndInvoice.Core.Application.Customers.GetCustomer;

public sealed record GetCustomersQuery : IRequest<List<CustomerResponse>>;