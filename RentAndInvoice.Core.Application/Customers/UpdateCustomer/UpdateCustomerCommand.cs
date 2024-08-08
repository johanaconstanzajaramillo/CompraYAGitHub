using MediatR;
using RentAndInvoice.Core.Domain.Entities.Customers;

namespace RentAndInvoice.Core.Application.Customers.UpdateCustomer;

public record UpdateCustomerCommand(CustomerId CustomerId, byte documentTypeId, string documentNumber, string name, string email, List<string> phones, List<string> addresses, byte customerType) :IRequest;

public record UpdateCustomerRequest(byte documentTypeId, string documentNumber, string name, string email, List<string> phones, List<string> addresses, byte customerType) : IRequest;
