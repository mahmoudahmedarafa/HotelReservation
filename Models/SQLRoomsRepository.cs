using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class SQLRoomsRepository : IRoomsRepository
    {
        private readonly HotelReservationContext context;
        public IEnumerable<Rooms> GetAllRooms()
        {
            return context.Rooms;
        }
    }
}
