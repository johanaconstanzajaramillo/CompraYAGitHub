using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentAndInvoice.Core.Application.Security.CreateRole;
using RentAndInvoice.Core.Application.Security.DeleteRole;
using RentAndInvoice.Core.Application.Security.GetRole;
using RentAndInvoice.Core.Application.Security.UpdateRole;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.WebAPI.Endpoints.Security;

public class Roles : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("roles", async (CreateRoleCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        }).RequireAuthorization();

        app.MapPut("roles/{id:int}", async (int id, [FromBody] UpdateRoleRequest request, ISender sender) =>
        {
            var command = new UpdateRoleCommand(
                new RoleId((byte)id),
                request.Name,
                request.Priority,
                request.Pages);
            await sender.Send(command);

            return Results.Ok();
        }).RequireAuthorization();

        app.MapGet("roles", async (ISender sender) =>
        {
            try
            {
                List<RoleResponse> roles = await sender.Send(new GetRolesQuery());
                return Results.Ok(roles);
            }
            catch (RoleNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }).RequireAuthorization();

        app.MapGet("roles/{id:int}", async (int id, ISender sender) =>
        {
            try
            {
                RoleResponse product = await sender.Send(new GetRoleQuery(new RoleId((byte)id)));
                return Results.Ok(product);
            }
            catch (RoleNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }).RequireAuthorization();

        app.MapDelete("roles/{id:int}", async (int id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteRoleCommand(new RoleId((byte)id)));

                return Results.NoContent();
            }
            catch (RoleNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }).RequireAuthorization();

    }
}
