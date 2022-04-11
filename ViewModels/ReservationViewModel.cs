using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.ViewModels
{
    public class ReservationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int NoOfAdults { get; set; }
        [Required]
        public int NoOfChildren { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public string MealPlan { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        public int TotalReservationCost { get; set; }
    }
}
