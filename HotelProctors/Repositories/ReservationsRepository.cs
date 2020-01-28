using HotelProctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace HotelProctors.Repositories
{
    public class ReservationsRepository
    {   
        public IEnumerable<Reservation> GetReservations()
        {
            List<Reservation> reservations;
            
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    reservations = db.Reservations
                          .Include("ApplicationUser")
                          .Include("Room")
                          .OrderBy(r => r.ArrivalDate)
                          .ToList();

                }

                return reservations;
            
         
          
        }

        public IEnumerable<Reservation> GetReservationsFuture()
        {
            IEnumerable<Reservation> reservations;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                reservations = db.Reservations
                      .Include("ApplicationUser")
                      .Include("Room")
                      .Where(r => r.ArrivalDate >= DateTime.Now)
                      .ToList();

            }

            return reservations;
        }

        public List<Reservation> GetUserReservations(string id)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (var db = new ApplicationDbContext())
            {
               
                reservations = db.Reservations.Include("Room").Where(reservation =>reservation.UserId==id).ToList();
                
            }

            return reservations;
        }

        public  bool IsValid(object value)
        {
            DateTime dt;

            bool isValid = DateTime.TryParse(Convert.ToString(value), out dt);

            return (isValid && dt >= DateTime.Now);
        }

        public bool CheckReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException("reservation");
            }
            try {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    Room room = db.Rooms.Find(reservation.RoomId);
                    bool check = false;
                    if (room.Reservations.Count == 0)
                    {

                        return check = true;
                    }
                    foreach (Reservation r in room.Reservations)
                    {
                        if (reservation.ArrivalDate > r.ArrivalDate)
                        {
                            if (reservation.DepartureDate <= r.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (reservation.ArrivalDate < r.DepartureDate)
                            {
                                check = false;
                                break;
                            }

                            check = true;
                        }
                        else if (reservation.ArrivalDate < r.ArrivalDate)
                        {
                            if (reservation.DepartureDate > r.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (reservation.DepartureDate > r.ArrivalDate)
                            {
                                check = false;
                                break;
                            }

                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }

                    }
                    if (check == true)
                    {
                        return check;

                    }
                    else
                    {
                        return check;
                    }

                }
            }
            catch {
                return false;
            }
            

        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                }
            }
            catch { }
           
        }


        public Reservation FindById(int id)
        {

            Reservation reservation;

            using (var db = new ApplicationDbContext())
            {
                reservation = db.Reservations
                        .Include("ApplicationUser")
                        .Include("Room")
                        .SingleOrDefault(i => i.Id == id);
            }
           
            return reservation;
        }


        public void UpdateReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                using (var db = new ApplicationDbContext())
                {

                    db.Reservations.Attach(reservation);
                    db.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch { }
          
        }


        public void DeleteReservation(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var reservation = db.Reservations.Find(id);
                    db.Reservations.Remove(reservation);
                    db.SaveChanges();
                }
            }
            catch { }
           
        }

     


    }
}