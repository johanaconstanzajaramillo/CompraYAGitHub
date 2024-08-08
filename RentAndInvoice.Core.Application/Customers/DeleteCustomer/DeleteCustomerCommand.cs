using MediatR;
using RentAndInvoice.Core.Domain.Entities.Customers;

namespace RentAndInvoice.Core.Application.Products.DeleteCategory;

public record DeleteCustomerCommand(CustomerId CustomerId) : IRequest;