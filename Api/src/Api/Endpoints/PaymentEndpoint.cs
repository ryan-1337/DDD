using Application.Payments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class PaymentEndpoint
{
    public static void MapPayment(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/payments", async (
            [FromServices] ISender sender, 
            [FromBody] CreatePaymentQuery query) =>
        {
            await sender.Send(query);
            return Results.Ok();
        });
    } 
}