using HotelProctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProctors.Repositories
{
    public class AmenitiesRepository
    {
        public IEnumerable<AmenitiesPerRoom> GetAmenities()
        {
            IEnumerable<AmenitiesPerRoom> amenities;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                amenities = db.Amenities.Include("Rooms").ToList();
            }

            return amenities;
        }

        public void AddAmenities(AmenitiesPerRoom amenities)
        {
            if (amenities == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Amenities.Add(amenities);
                    db.SaveChanges();
                }
            }
            catch { }
           
        }

       
        public void UpdateAmenities(AmenitiesPerRoom amenities)
        {
            if (amenities == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Amenities.Attach(amenities); ;
                    db.Entry(amenities).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch { }
          
        }

        public void DeleteAmenities(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var meal = db.Amenities.Find(id);
                    db.Amenities.Remove(meal);
                    db.SaveChanges();
                }
            }
            catch { }
           
        }

        public AmenitiesPerRoom FindById(int id)
        {

            AmenitiesPerRoom amenities;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                amenities = db.Amenities.Find(id);
            }

            return amenities;
        }

    }
}