using HotelProctors.Models;
using HotelProctors.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelProctors.Repositories
{
    public class RoomsRepository
    {
        public IEnumerable<Room> GetRooms()
        {
            IEnumerable<Room> rooms;
          

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               
                rooms = db.Rooms
                     .Include("Reservations")
                     .Include("Amenities")
                     .OrderBy(r=>r.Price)
                     .ToList();
            }

            return rooms;
        }
        public IEnumerable<Room> GetRoomTypesGeneral()
        {
            List<Room> rooms = new List<Room>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var ClassicRoom = db.Rooms.FirstOrDefault(i => i.RoomType == RoomType.ClassicRoom);
                rooms.Add(ClassicRoom);
                var ClassicSuite = db.Rooms.FirstOrDefault(i => i.RoomType == RoomType.ClassicSuite);
                rooms.Add(ClassicSuite);
                var PremiumRoom = db.Rooms.FirstOrDefault(i => i.RoomType == RoomType.PremiumRoom);
                rooms.Add(PremiumRoom);
                var PremiumSuite = db.Rooms.FirstOrDefault(i => i.RoomType == RoomType.PremiumSuite);
                rooms.Add(PremiumSuite);
            }
            return rooms;
        }


        public IEnumerable<Room> GetRoomTypes(RoomType roomType)
        {
            List<Room> rooms = new List<Room>();


            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               
                foreach (var item in db.Rooms)
                {
                    if (roomType == item.RoomType)
                    {
                        rooms.Add(item);
                    }

                }
            }

            return rooms.OrderBy(r => r.Price);
        }


        public void AddRoom(Room room)
        {
            if (room == null) 
            {
                throw new ArgumentNullException();
            }
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Rooms.Add(new Room
                {
                    Price = room.Price,
                    Description = room.Description,
                    RoomType = room.RoomType,
                    Floor = room.Floor,
                    View = room.View,
                    Bed = room.Bed,
                    Size = room.Size,
                    AmenitiesId=room.AmenitiesId,
                    ProfilePicture = room.ProfilePicture
                });
               
                db.SaveChanges();
            }
        }

        public void UpdateRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException();
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Rooms.Attach(room);
                db.Entry(room).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteRoom(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var room = db.Rooms.Find(id);
                db.Rooms.Remove(room);
                db.SaveChanges();
            }
        }


        public Room FindById(int id)
        {

           
                Room room;
                using (ApplicationDbContext db = new ApplicationDbContext())

                {
                    room = db.Rooms.Include("Reservations").Include("Amenities").SingleOrDefault(i => i.Id == id);
                }

                return room;
            
           
        }
        public IEnumerable<Room> GetFreeRooms(DateTime start, DateTime end, RoomType roomType)
        {
            var freeRooms = new List<Room>();
            var rooms = new List<Room>();
           
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                foreach (var item in db.Rooms.Include("Amenities"))
                {
                    if (item.RoomType == roomType)
                    {
                        
                        rooms.Add(item);
                    }
                }
               
                foreach (Room r in rooms)
                {
                    if (r.Reservations.Count == 0)
                    {
                        freeRooms.Add(r);
                        break;
                       
                    }
                    var check = false;
                    foreach (var item in r.Reservations)
                    {

                        if (start > item.ArrivalDate)
                        {
                            if (end <= item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (start < item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            check = true;
                        }
                        else if(start<item.ArrivalDate)
                        {
                            if (end > item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (end > item.ArrivalDate)
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
                        freeRooms.Add(r);
                       
                    }
                  
                }
                return freeRooms.OrderBy(r => r.Price);
            }
        
            }

        public IEnumerable<Room> GetAllFreeRooms(DateTime start, DateTime end)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {


                var freeRooms = new List<Room>();
                var rooms = new List<Room>();
                foreach (var item in db.Rooms.Include("Amenities"))
                {

                   rooms.Add(item);
                    
                }
                foreach (Room r in rooms)
                {
                    if (r.Reservations.Count == 0)
                    {
                        freeRooms.Add(r);
                        break;

                    }
                    var check = false;
                    foreach (var item in r.Reservations)
                    {
                        if (start > item.ArrivalDate)
                        {
                            if (end <= item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (start < item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            check = true;
                        }
                        else if (start < item.ArrivalDate)
                        {
                            if (end > item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (end > item.ArrivalDate)
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
                        freeRooms.Add(r);

                    }
                }
                return freeRooms.OrderBy(r => r.Price);

            }

        }

        public IEnumerable<Room> GetAdvancedFreeRooms(DateTime start, DateTime end, RoomType roomType, MaxPersons maxPersons)
        {
            var freeRooms = new List<Room>();
            var rooms = new List<Room>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                foreach (var item in db.Rooms)
                {
                    if (item.RoomType == roomType && item.MaxPersons == maxPersons)
                    {

                        rooms.Add(item);
                    }
                }

                foreach (Room r in rooms)
                {
                    if (r.Reservations.Count == 0)
                    {
                        freeRooms.Add(r);
                        break;

                    }
                    var check = false;
                    foreach (var item in r.Reservations)
                    {
                        if (start > item.ArrivalDate)
                        {
                            if (end <= item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (start < item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            check = true;
                        }
                        else if (start < item.ArrivalDate)
                        {
                            if (end > item.DepartureDate)
                            {
                                check = false;
                                break;
                            }
                            if (end > item.ArrivalDate)
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
                        freeRooms.Add(r);

                    }
                }
                return freeRooms.OrderBy(r => r.Price);
            }
        
        }
        public List<Reservation> GetRoomReservations(int id)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (var db = new ApplicationDbContext())
            {

                reservations = db.Reservations.Include("Room").Include("ApplicationUser").Where(reservation => reservation.RoomId == id).ToList();

            }

            return reservations;
        }


        

       
    }
}