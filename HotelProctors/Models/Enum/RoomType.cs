using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelProctors.Models.Enum
{
    public enum RoomType
    {

        [Display(Name = "Classic Room")]
        ClassicRoom,
        [Display(Name = "Premium Room")]
        PremiumRoom,
        [Display(Name = "Classic Suite")]
        ClassicSuite,
        [Display(Name = "Premium Suite")]
        PremiumSuite
    }
}