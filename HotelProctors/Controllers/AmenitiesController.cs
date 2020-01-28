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
    public class AmenitiesController : Controller
    {
        private readonly AmenitiesRepository _amenitiesRepository = new AmenitiesRepository();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_amenitiesRepository.GetAmenities());
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(AmenitiesPerRoom amenities)
        {
            if (!ModelState.IsValid)
            {
                return View(amenities);
            }

            _amenitiesRepository.AddAmenities(amenities);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var amenities = _amenitiesRepository.FindById(id);
            return View(amenities = _amenitiesRepository.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AmenitiesPerRoom amenities)
        {
            if (!ModelState.IsValid)
            {
                return View(amenities);
            }

            _amenitiesRepository.UpdateAmenities(amenities);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var amenities = _amenitiesRepository.FindById(id);
            return View(amenities);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _amenitiesRepository.DeleteAmenities(id);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var amenities = _amenitiesRepository.FindById(id);
            return View(amenities);
        }





    }
}