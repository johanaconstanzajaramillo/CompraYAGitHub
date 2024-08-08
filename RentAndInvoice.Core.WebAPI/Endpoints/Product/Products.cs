using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentAndInvoice.Core.Application.Products.CreateProduct;
using RentAndInvoice.Core.Application.Products.DeleteProduct;
using RentAndInvoice.Core.Application.Products.GetProduct;
using RentAndInvoice.Core.Application.Products.UpdateProduct;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.WebAPI.Endpoints.Product;

public class Products : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("products", async (CreateProductCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapPut("products/{id:guid}", async (Guid id, [FromBody] UpdateProductRequest request, ISender sender) =>
        {
            var command = new UpdateProductCommand(
                new ProductId(id),
                request.Name,
                request.Currency,
                request.Ammount,
                request.AmmountStock,
                request.CategoryId,
                request.Enabled);
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("products", async (ISender sender) =>
        {
            try
            {
                List<ProductResponse> products = await sender.Send(new GetProductsQuery());
                return Results.Ok(products);
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("products/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                ProductResponse product = await sender.Send(new GetProductQuery(new ProductId(id)));
                return Results.Ok(product);
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("products/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteProductCommand(new ProductId(id)));

                return Results.NoContent();
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
