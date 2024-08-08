using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentAndInvoice.Core.Application.Products.CreateCategory;
using RentAndInvoice.Core.Application.Products.DeleteCategory;
using RentAndInvoice.Core.Application.Products.GetCategory;
using RentAndInvoice.Core.Application.Products.UpdateCategory;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.WebAPI.Endpoints.Product;

public class Categories : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (CreateCategoryCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapPut("categories/{id:guid}", async (Guid id, [FromBody] UpdateCategoryRequest request, ISender sender) =>
        {
            var command = new UpdateCategoryCommand(
                new CategoryId(id),
                request.Name,
                request.Enabled);
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("categories", async (ISender sender) =>
        {
            try
            {
                List<CategoryResponse> categories = await sender.Send(new GetCategoriesQuery());
                return Results.Ok(categories);
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("categories/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                CategoryResponse category = await sender.Send(new GetCategoryQuery(new CategoryId(id)));
                return Results.Ok(category);
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("categories/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteCategoryCommand(new CategoryId(id)));

                return Results.NoContent();
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
