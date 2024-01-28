using Application.Wallets.Queries;
using Application.Wallets.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class WalletEndpoint
{
    public static void MapWallet(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/wallet/", async (
                [FromServices] ISender sender,
                [AsParameters] GetWalletByClientIdQuery query) =>
            {
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .Produces<WalletResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("GetWalletByClientId");

        app.MapPost("api/wallet", async (
                [FromServices] ISender sender,
                [FromBody] CreateWalletQuery query) =>
            {
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithTags("CreateWallet");
        
         app.MapPut("api/wallet", async (
                 [FromServices] ISender sender,
                 [AsParameters] UpdateWalletQuery query) =>
             {
                 var response = await sender.Send(query);
                 return Results.Ok(response);
             })
             .Produces(StatusCodes.Status202Accepted)
             .Produces(StatusCodes.Status400BadRequest)
             .WithTags("UpdateWallet");       
    } 
}