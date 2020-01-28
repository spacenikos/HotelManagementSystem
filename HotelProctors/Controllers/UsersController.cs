using HotelProctors.Models;
using HotelProctors.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelProctors.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        private readonly UsersRepository _usersRepository = new UsersRepository();
        private readonly ReservationsRepository _reservationsRepository = new ReservationsRepository();
        // GET: Users
        
        public ActionResult UserProfile()
        {

            var userId = User.Identity.GetUserId();


            try
            {
                var user = _usersRepository.FindUserById(userId);
                user.Reservations = _reservationsRepository.GetUserReservations(userId);
                return View(user);
            }
            catch
            {

                return RedirectToAction("Index", "Home");

            }



        }
        [Authorize(Users = "admin@proctors.com")]
        public ActionResult ListOfUsers()
        {
           
            return View(_usersRepository.GetApplicationUsers());

        }

        public ActionResult Edit(string id)
        {
            try
            {
                var user = _usersRepository.FindUserById(id);
                return View(user);
            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
        
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Edit(ApplicationUser user)
        {


            _usersRepository.Edit(user);
            return RedirectToAction("ListOfUsers");
        }
        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                var user = _usersRepository.FindUserById(id);
                user.Reservations = _reservationsRepository.GetUserReservations(id);
                return View(user);
            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
           
        }
        [Authorize]
        public ActionResult SearchUser(string searchTerm)
        {
            IEnumerable<ApplicationUser> users = null;

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    users = _usersRepository.SearchUsers(searchTerm);
                }
                return View(users);
           
        }

    }

}