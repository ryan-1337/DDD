using Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class RoomTest
    {
        [Fact]
        public void CreateRoom_ShouldSetName()
        {
            var room = new Room("Room 101", 100.0m, new List<string> { "Wifi", "TV" });

            Assert.Equal("Room 101", room.Name);
        }

        [Fact]
        public void CreateRoom_ShouldSetPricePerNight()
        {
            var room = new Room("Room 101", 100.0m, new List<string> { "Wifi", "TV" });

            Assert.Equal(100.0m, room.PricePerNight);
        }

        [Fact]
        public void CreateRoom_ShouldSetOptions()
        {
            var options = new List<string> { "Wifi", "TV" };
            var room = new Room("Room 101", 100.0m, options);

            Assert.Equal(options, room.Options);
        }
    }
}