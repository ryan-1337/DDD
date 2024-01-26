using Application.Wallets.Queries;
using Application.Wallets.Responses;
using Domain;
using MediatR;

namespace Application.Rooms.Handlers;

public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsQuery, List<RoomResponse>>
{
   private readonly IRoomRepository _roomRepository;

   public GetAllRoomsHandler(IRoomRepository roomRepository)
   {
      _roomRepository = roomRepository;
   }

   public async Task<List<RoomResponse>> Handle(GetAllRoomsQuery query, CancellationToken cancellationToken)
   {
      var rooms = await _roomRepository.GetAllAsync();
       
      var roomResponses = rooms.Select(room => new RoomResponse
      {
         Id = room.Id,
         Name = room.Name,
         PricePerNight = room.PricePerNight,
         Options = room.Options
      }).ToList();

      return roomResponses;
   }
}