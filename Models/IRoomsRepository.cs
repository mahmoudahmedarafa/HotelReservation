using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public interface IRoomsRepository
    {
        IEnumerable<Rooms> GetAllRooms();
    }
}
