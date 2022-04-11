using System;
using System.Collections.Generic;

namespace HotelReservation.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string RoomType { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }

        public bool IsReserved { get; set; }

        public virtual ICollection<Users> Users { get; set; }

        public static string GetRoomTypeFromEnum(string roomTypeNum)
        {
            if (roomTypeNum == "1")
                return "Standard";
            else if (roomTypeNum == "2")
                return "SeaView";
            else if (roomTypeNum == "3")
                return "PoolView";

            return "";
        }
    }
}
