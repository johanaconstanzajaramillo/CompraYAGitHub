using MediatR;

namespace RentAndInvoice.Core.Application.Security.GetPage;

public record GetPagesQuery() : IRequest<List<PageResponse>>;

public record PageResponse(
    byte Id,
    string Name,
    string Url,
    bool Enabled
    );

public record PageRequest(
    byte id
    ) : IRequest;
