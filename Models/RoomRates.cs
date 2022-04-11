using System;
using System.Collections.Generic;

namespace HotelReservation.Models
{
    public partial class RoomRates
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RatePerRoom { get; set; }
    }
}
