using Application.Wallets.Queries;
using Application.Wallets.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class WalletEndpoint
{
    public static void MapWallet(this IEndpointRouteBuilder app)
    {
        app.MapGet("/wallet/{clientId}", async (
                [FromServices] ISender sender,
                [FromRoute] string clientId) =>
            {
                var query = new GetWalletByClientIdQuery { ClientId = clientId };
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .Produces<WalletResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("GetWalletByClientId");

        app.MapPost("/wallet", async (
                [FromServices] ISender sender,
                [FromBody] CreateWalletQuery query) =>
            {
                await sender.Send(query);
                return Results.Ok();
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithTags("CreateWallet");
        
         app.MapPut("/wallet", async (
                 [FromServices] ISender sender,
                 [FromBody] UpdateWalletQuery query) =>
             {
                 await sender.Send(query);
                 return Results.Ok();
             })
             .Produces(StatusCodes.Status202Accepted)
             .Produces(StatusCodes.Status400BadRequest)
             .WithTags("UpdateWallet");       
    } 
}