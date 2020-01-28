using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProctors.Models
{
    public class MealViewModel
    {
        public Meal Meal { get; set; } 
        public HttpPostedFileBase postedFile { get; set; }
    }
}