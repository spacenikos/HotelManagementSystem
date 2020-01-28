using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HotelProctors.Models.Enum;

namespace HotelProctors.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate]
        [Display(Name="Arrival")]
        
        public DateTime ArrivalDate { get; set; }
      
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate]
        [Display(Name = "Departure")]

        public DateTime DepartureDate { get; set; }



        [Display(Name = "Application User")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Room Number")]
        public int RoomId { get; set; }
    
        public virtual Room Room { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? TotalCost
        {
            get { return Room.Price * DepartureDate.Subtract(ArrivalDate).Days; }
        }

      
    }
}