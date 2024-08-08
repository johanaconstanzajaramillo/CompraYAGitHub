using MediatR;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.UpdatePage;

public sealed class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand>
{
    private readonly IPageRepository _pageRepository;
    public UpdatePageCommandHandler(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }
    public Task Handle(UpdatePageCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        var page = _pageRepository.GetByIdAsync(request.Id);

        if (page is null)
        {
            throw new PageNotFoundException(request.Id);
        }

        page.Update(request.Enabled);

        _pageRepository.Update(page);
        return Task.CompletedTask;
    }
}
