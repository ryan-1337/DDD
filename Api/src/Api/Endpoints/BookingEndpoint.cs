using Application.Bookings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class BookingEndpoint
{
    
    public static void MapBooking(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/booking", async (
                [FromServices] ISender sender, CreateBookingQuery query) =>
            {
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .WithTags("CreateBooking");
        
        app.MapGet("api/booking", async (
                [FromServices] ISender sender, [AsParameters] GetAllBookingByClientIdQuery query) =>
            {
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .WithTags("GetAllBookingByClientId");
        
        
        app.MapPut("api/booking", async (
                [FromServices] ISender sender, [AsParameters] UpdateBookingQuery query) => 
            {
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .WithTags("UpdateBooking");
    }
}