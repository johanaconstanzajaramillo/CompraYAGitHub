using MediatR;
using RentAndInvoice.Core.Application.Data;

namespace RentAndInvoice.Core.Application.Security.GetPage;

internal sealed class GetPagesQueryHandler : IRequestHandler<GetPagesQuery, List<PageResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetPagesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<List<PageResponse>> Handle(GetPagesQuery request, CancellationToken cancellationToken)
    {
        var pages = _context
           .Pages
           .Select(p => new PageResponse(
               p.Id.Value,
               p.Name,
               p.Url,
               p.Enabled))
           .ToList();

        return Task.FromResult(pages.OrderBy(p=>p.Id).ToList());
    }
}
