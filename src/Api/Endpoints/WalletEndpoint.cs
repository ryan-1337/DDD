using Application.Wallets.Queries;
using Application.Wallets.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class WalletEndpoint
{
    public static void MapWallet(this IEndpointRouteBuilder app)
    {
        app.MapGet("/wallets/{clientId}", async (
                [FromServices] ISender sender,
                [FromRoute] string clientId) =>
            {
                var query = new GetWalletByClientIdQuery { ClientId = clientId };
                await sender.Send(query);
                return Results.Ok();
            })
            .Produces<WalletResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetWalletByClientId");

        app.MapPost("/wallets", async (
                [FromServices] ISender sender,
                [FromBody] CreateWalletQuery query) =>
            {
                await sender.Send(query);
                return Results.Ok();
            })
            .WithName("CreateWallet");
    } 
}