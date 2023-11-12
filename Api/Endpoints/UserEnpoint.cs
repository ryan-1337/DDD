using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class UserEnpoint
{
    public static void MapUser(this IEndpointRouteBuilder app)
    {
        app.MapPost("/users", async ([FromServices] ISender sender, [FromBody] CreateUserQuery query) =>
        {
            await sender.Send(query);

            return Results.Ok();
        });
    }
}
