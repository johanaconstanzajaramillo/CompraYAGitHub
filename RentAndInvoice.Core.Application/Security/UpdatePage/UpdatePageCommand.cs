using MediatR;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Security.UpdatePage;

public record UpdatePageCommand(PageId Id, bool Enabled) : IRequest;



public record UpdatePageRequest(
    bool Enabled
    ) : IRequest;
