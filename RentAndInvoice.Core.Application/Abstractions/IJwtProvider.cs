using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Abstractions;
public interface IJwtProvider
{
    string Generate(User user);
}
