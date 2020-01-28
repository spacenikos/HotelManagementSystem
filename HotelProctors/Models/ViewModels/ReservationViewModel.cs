using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProctors.Models
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public Room Room { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}