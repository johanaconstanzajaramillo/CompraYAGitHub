using RentAndInvoice.Core.Application.Security.GetPage;
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Security.UpdatePage;

public static class PageExtensions
{
    public static Page ToEntity(this PageRequest pageCommand, IPageRepository pageRepository)
    {
        var eFPage = pageRepository.GetByIdAsync(new PageId(pageCommand.id));

        if (eFPage is null)
        {
            throw new PageNotFoundException(new PageId(pageCommand.id));
        }

        return eFPage;
    }

    public static List<Page> ToEntities(this IEnumerable<PageRequest> pageCommands, IPageRepository pageRepository)
    {
        var pages = new List<Page>();

        foreach (var pageCommand in pageCommands)
        {
            var eFPage = pageCommand.ToEntity(pageRepository);
            pages.Add(eFPage);
        }

        return pages;
    }

    public static PageResponse ToEntity(this Page pageCommand, IPageRepository pageRepository)
    {
        var pageResponse = pageRepository.GetByIdAsync(pageCommand.Id);

        if (pageResponse is null)
        {
            throw new PageNotFoundException(pageCommand.Id);
        }

        return new PageResponse(pageResponse.Id.Value,pageResponse.Name, pageResponse.Url,pageResponse.Enabled);
    }

    public static List<PageResponse> ToEntities(this IEnumerable<Page> pageCommands, IPageRepository pageRepository)
    {
        var pages = new List<PageResponse>();

        foreach (var pageCommand in pageCommands)
        {
            var pageResponse = pageCommand.ToEntity(pageRepository);
            pages.Add(pageResponse);
        }

        return pages;
    }
}