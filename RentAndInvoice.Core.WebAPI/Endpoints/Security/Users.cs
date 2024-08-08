using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentAndInvoice.Core.Application.Security.CreateUser;
using RentAndInvoice.Core.Application.Security.DeleteUser;
using RentAndInvoice.Core.Application.Security.GetUser;
using RentAndInvoice.Core.Application.Security.Login;
using RentAndInvoice.Core.Application.Security.UpdateUser;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.WebAPI.Endpoints.Security;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("users", async (CreateUserCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        }).RequireAuthorization();

        app.MapPut("users/{id:int}", async (int id, [FromBody] UpdateUserRequest request, ISender sender) =>
        {
            var command = new UpdateUserCommand(
                new UserId(id),
                request.FirstName,
                request.LastName,
                request.Password,
                request.Email,
                request.Roles,
                request.Enabled
                );
            await sender.Send(command);

            return Results.Ok();
        }).RequireAuthorization();

        app.MapGet("users", async (ISender sender) =>
        {
            try
            {
                List<UserResponse> users = await sender.Send(new GetUsersQuery());
                return Results.Ok(users);
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }).RequireAuthorization();

        app.MapGet("users/{id:int}", async (int id, ISender sender) =>
        {
            try
            {
                UserResponse product = await sender.Send(new GetUserQuery(new UserId((byte)id)));
                return Results.Ok(product);
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }).RequireAuthorization();

        app.MapDelete("users/{id:int}", async (int id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteUserCommand(new UserId((byte)id)));

                return Results.NoContent();
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }).RequireAuthorization();

        app.MapPost("login", [AllowAnonymous] async ([FromBody] LoginRequest request, ISender sender) =>
        {
            var command = new LoginCommand(
                request.Email,
                request.Password
                );

            var result =await sender.Send(command);

            return Results.Ok(result);
        });

    }
}
