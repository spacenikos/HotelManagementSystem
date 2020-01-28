using HotelProctors.Models;
using HotelProctors.Models.Enum;
using HotelProctors.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;


namespace HotelProctors.Controllers
{
  [Authorize(Users = "admin@proctors.com")]
    
    public class RoomsController : Controller
    {
        private readonly RoomsRepository _roomsRepository = new RoomsRepository();
        private readonly AmenitiesRepository _amenitiesRepository = new AmenitiesRepository();
        private readonly ReservationsRepository _reservationsRepository = new ReservationsRepository();

        [AllowAnonymous]
        public ActionResult Index()
        {
            SearchViewModel vm = new SearchViewModel();
            vm.Rooms = _roomsRepository.GetRooms();
            vm.ArrivalDate = DateTime.Now;
            vm.DepartureDate = (DateTime.Now).AddDays(1);
                return View(vm);
        }
        [AllowAnonymous]

        public ActionResult IndexRoomTypes(RoomType roomType)
            {
                SearchViewModel vm = new SearchViewModel();
                vm.Rooms = _roomsRepository.GetRoomTypes(roomType);
            return View(vm);
        }



        [HttpGet]
            public ActionResult Create()
            {
            RoomViewModel vm = new RoomViewModel();
            vm.Amenities = _amenitiesRepository.GetAmenities().ToList();
            
                return View(vm);
            }

            [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel vm)
        {
            if (vm.postedFile != null) {
                //Extract Image File Name.
                string fileName = System.IO.Path.GetFileName(vm.postedFile.FileName);

                //Set the Image File Path.
                string filePath = "/Uploads/" + fileName;

                //Save the Image File in Folder.
                vm.postedFile.SaveAs(Server.MapPath(filePath));
                vm.Room.ProfilePicture = filePath;
             
            }
            
            if (!ModelState.IsValid)
            {
                return View(vm.Room);
            }



            _roomsRepository.AddRoom(vm.Room);
            
            return RedirectToAction("Index");
        }

            public ActionResult Edit(int id)
            {
            RoomViewModel vm = new RoomViewModel();
            ViewBag.Amenities = _amenitiesRepository.GetAmenities();
            vm.Room = _roomsRepository.FindById(id);
            

            return View(vm);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(RoomViewModel vm)
            {

            if (vm.postedFile !=null)
            {


                //Extract Image File Name.
                string fileName = System.IO.Path.GetFileName(vm.postedFile.FileName);

                //Set the Image File Path.
                string filePath = "/Uploads/" + fileName;

                //Save the Image File in Folder.
                vm.postedFile.SaveAs(Server.MapPath(filePath));
                vm.Room.ProfilePicture = filePath;
            }

            if (!ModelState.IsValid)
                {
                    return View(vm.Room);
                }
            
                _roomsRepository.UpdateRoom(vm.Room);

                return RedirectToAction("Index");
            }

            
            public ActionResult Delete(int id)
            {
                
                return View(_roomsRepository.FindById(id));
            }

            [HttpPost]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirm(int id)
            {
                _roomsRepository.DeleteRoom(id);
                return RedirectToAction("Index");
            }
       
      
        public ActionResult Details(int id)
            {
                var room = _roomsRepository.FindById(id);
            room.Reservations = _roomsRepository.GetRoomReservations(id);
                return View(room);
            }
        [AllowAnonymous]

        public ActionResult SingleRoom(int id)
        {
            SearchViewModel vm = new SearchViewModel();
                vm.Room = _roomsRepository.FindById(id);
            return View(vm);
        }
        [AllowAnonymous]

        public ActionResult GetFreeRooms(SearchViewModel vm)
        {
            if ((!(_reservationsRepository.IsValid(vm.ArrivalDate))) || (!(_reservationsRepository.IsValid(vm.ArrivalDate))))
            {
                
                return RedirectToAction("Index","Home");
            }
            vm.Rooms=_roomsRepository.GetFreeRooms(vm.ArrivalDate, vm.DepartureDate, vm.Room.RoomType);
            if (vm.Rooms.Count() == 0)
            {
                ViewBag.RoomsAvailability = "No Rooms Available in this period";
            }

            return View(vm);

        }
        [AllowAnonymous]

        public ActionResult AdvancedGetFreeRooms(SearchViewModel vm)
        {


            if ((!(_reservationsRepository.IsValid(vm.ArrivalDate))) || (!(_reservationsRepository.IsValid(vm.ArrivalDate))))
            {
                return RedirectToAction("Index", "Home");
            }

            vm.Rooms = _roomsRepository.GetAdvancedFreeRooms(vm.ArrivalDate, vm.DepartureDate, vm.Room.RoomType, vm.Room.MaxPersons);
            if (vm.Rooms.Count() == 0)
            {
                ViewBag.RoomsAvailability = "No Rooms Available in this period";
            }
            return View(vm);

        }

   




    }
}