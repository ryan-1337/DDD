using Application.Wallets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class RoomEndpoint
{
    public static void MapRoom(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/rooms", async (
                [FromServices] ISender sender) =>
            {
                var query = new GetAllRoomsQuery();
                var response =await sender.Send(query);
                return Results.Ok(response);
            })
            .WithTags("GetAllRooms");
    }
}