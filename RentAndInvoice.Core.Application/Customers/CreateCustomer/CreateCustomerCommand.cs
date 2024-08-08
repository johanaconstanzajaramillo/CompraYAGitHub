using MediatR;
using RentAndInvoice.Core.Domain.Entities.Customers;

namespace RentAndInvoice.Core.Application.Customers.CreateCustomer;

public record CreateCustomerCommand(byte documentTypeId, string documentNumber, string name, string email, List<string> phones, List<string> addresses, byte customerType) :IRequest;
