using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelProctors.Models.Enum
{
    public enum Floor
    {
      
        [Display(Name = "1")]
        One,
        [Display(Name = "2")]
        Two,
        [Display(Name = "3")]
        Three,
        [Display(Name = "4")]
        Four,
        [Display(Name = "5")]
        Five,
        [Display(Name = "6")]
        Six,
        [Display(Name = "7")]
        Seven
    }
}