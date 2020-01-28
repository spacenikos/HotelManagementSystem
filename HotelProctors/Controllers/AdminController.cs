using HotelProctors.Models;
using HotelProctors.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelProctors.Controllers
{
    [Authorize(Users = "admin@proctors.com")]
    public class AdminController : Controller
    {
        private readonly RoomsRepository _roomsRepository = new RoomsRepository();
        private readonly AmenitiesRepository _amenitiesRepository = new AmenitiesRepository();
        private readonly ReservationsRepository _reservationsRepository = new ReservationsRepository();
        
        public ActionResult Reservations()
        {
            return RedirectToAction("IndexFuture", "Reservations");
        }
        public ActionResult Rooms()
        {
            SearchViewModel vm = new SearchViewModel();
            vm.Rooms = _roomsRepository.GetRooms();
            return View(vm);
        }
        public ActionResult AvailableRooms(SearchViewModel vm)
        {
            if ((!(_reservationsRepository.IsValid(vm.ArrivalDate))) || (!(_reservationsRepository.IsValid(vm.ArrivalDate))))
            {
                return RedirectToAction("Index", "Home");
            }

            vm.Rooms = _roomsRepository.GetAllFreeRooms(vm.ArrivalDate, vm.DepartureDate);

            return View(vm);
        }
        public ActionResult Users()
        {
            return RedirectToAction("ListOfUsers", "Users");
        }
        public ActionResult Meals()
        {
            return View();
        }

        public ActionResult Amenities()
        {
            return RedirectToAction("Index", "Amenities");

        }

       
    }
}