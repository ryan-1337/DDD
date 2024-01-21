using Application.Clients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class ClientEnpoint
{
    public static void MapClient(this IEndpointRouteBuilder app)
    {
        app.MapPost("/clients", async (
            [FromServices] ISender sender, 
            [FromBody] CreateClientQuery query) =>
        {
            await sender.Send(query);
            return Results.Ok();
        });
    }
}
