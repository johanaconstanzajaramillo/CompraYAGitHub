using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentAndInvoice.Core.Application.Customers.CreateCustomer;
using RentAndInvoice.Core.Application.Customers.GetCustomer;
using RentAndInvoice.Core.Application.Customers.UpdateCustomer;
using RentAndInvoice.Core.Application.Products.DeleteCategory;
using RentAndInvoice.Core.Domain.Entities.Customers;

namespace RentAndInvoice.Core.WebAPI.Endpoints.General;

public class Customers : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("customers", async (CreateCustomerCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapPut("customers/{id:guid}", async (Guid id, [FromBody] UpdateCustomerRequest request, ISender sender) =>
        {
            var command = new UpdateCustomerCommand(
                new CustomerId(id),
                request.documentTypeId,
                request.documentNumber,
                request.name,
                request.email,
                request.phones,
                request.addresses,
                request.customerType);
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("customers", async (ISender sender) =>
        {
            try
            {
                List<CustomerResponse> customers = await sender.Send(new GetCustomersQuery());
                return Results.Ok(customers);
            }
            catch (CustomerNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("customers/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                CustomerResponse customer = await sender.Send(new GetCustomerQuery(new CustomerId(id)));
                return Results.Ok(customer);
            }
            catch (CustomerNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("customers/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteCustomerCommand(new CustomerId(id)));

                return Results.NoContent();
            }
            catch (CustomerNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
