using Application.Bookings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class BookingEndpoint
{
    
    public static void MapBooking(this IEndpointRouteBuilder app)
    {
        app.MapPost("/booking", async (
                [FromServices] ISender sender, CreateBookingQuery query) =>
            {
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .WithTags("CreateBooking");
    }
}