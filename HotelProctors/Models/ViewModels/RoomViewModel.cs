using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProctors.Models
{
    public class RoomViewModel
    {
        
        public  Room Room { get;set;}
        public List<AmenitiesPerRoom> Amenities { get; set; }
        public HttpPostedFileBase postedFile { get; set; }
    }
}