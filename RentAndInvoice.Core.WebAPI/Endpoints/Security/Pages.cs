using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentAndInvoice.Core.Application.Security.GetPage;
using RentAndInvoice.Core.Application.Security.UpdatePage;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.WebAPI.Endpoints.Security;

public class Pages : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPut("pages/{id:int}", async (int id, [FromBody] UpdatePageRequest request, ISender sender) =>
        {
            var command = new UpdatePageCommand(
                new PageId((byte)id),
                request.Enabled);
            await sender.Send(command);

            return Results.Ok();
        }).RequireAuthorization();

        app.MapGet("pages", async (ISender sender) =>
        {
            try
            {
                List<PageResponse> pages = await sender.Send(new GetPagesQuery());
                return Results.Ok(pages);
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }).RequireAuthorization();

    }
}
