using System;
using System.Collections.Generic;

namespace HotelReservation.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public int? Age { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int? RoomId { get; set; }

        public virtual Rooms Room { get; set; }
    }
}
