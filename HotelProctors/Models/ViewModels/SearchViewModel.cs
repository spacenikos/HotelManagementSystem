using HotelProctors.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelProctors.Models
{
    public class SearchViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Arrival")]
        [FutureDate]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name ="Departure")]
        [FutureDate]
        public DateTime DepartureDate { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<Room> RoomsIndex { get; set; }

        public Room Room { get; set; }

  
    }
}