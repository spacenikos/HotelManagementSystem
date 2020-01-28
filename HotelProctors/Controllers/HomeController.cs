using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelProctors.Repositories;
using HotelProctors.Models;
using Microsoft.AspNet.Identity;


namespace HotelProctors.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoomsRepository _roomsRepository = new RoomsRepository();
        private readonly ReservationsRepository _reservationsRepository = new ReservationsRepository();
        public ActionResult Index()
        {
            SearchViewModel vm = new SearchViewModel();
            vm.ArrivalDate = DateTime.Now;
            vm.DepartureDate = (DateTime.Now).AddDays(1);
            vm.Rooms = _roomsRepository.GetRoomTypesGeneral();
            vm.RoomsIndex = _roomsRepository.GetRooms();
            vm.Reservations = _reservationsRepository.GetReservations();

            
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            SearchViewModel vm = new SearchViewModel();
            vm.Rooms = _roomsRepository.GetRooms();
            vm.Reservations = _reservationsRepository.GetReservations();

            return View(vm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Your blog page";
            return View();
        }

        public ActionResult Restaurant()
        {
            ViewBag.Message = "Your restaurant page";
            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your services";
            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }

      
       
    }
}