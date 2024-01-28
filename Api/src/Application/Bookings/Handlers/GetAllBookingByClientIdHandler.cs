using Application.Bookings.Queries;
using Application.Bookings.Responses;
using Domain;
using MediatR;

namespace Application.Bookings.Handlers;

public class GetAllBookingByClientIdHandler : IRequestHandler<GetAllBookingByClientIdQuery, List<BookingResponse>>
{
    
    private readonly IBookingRepository _bookingRepository;

    public GetAllBookingByClientIdHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }


    public async Task<List<BookingResponse>> Handle(GetAllBookingByClientIdQuery query,
        CancellationToken cancellationToken)
    {
        
      var bookings = await _bookingRepository.GetAllAsync();
       
      var bookingResponses = bookings.Select(bookings => new BookingResponse
      {
         Id = bookings.Id.ToString(),
         ClientId = bookings.ClientId.ToString(),
         CheckInDate = bookings.CheckInDate,
         InitialPayment = bookings.InitialPayment,
         IsCancelled = bookings.IsCancelled,
         IsConfirmed = bookings.IsConfirmed,
         TotalAmount = bookings.TotalAmount,
         NumberOfNights = bookings.NumberOfNights,
         Room = bookings.Room
      }).ToList();

      return bookingResponses;
    }
}