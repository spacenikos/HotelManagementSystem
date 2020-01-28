using HotelProctors.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelProctors.Models
{
    public class Amenities
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        [Required]
        public bool Tv { get; set; }
        [Required]
        public bool AirCondition { get; set; }
        [Required]
        public bool Sauna { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}