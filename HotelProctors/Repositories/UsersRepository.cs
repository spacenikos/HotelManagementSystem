using HotelProctors.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelProctors.Repositories
{
    public class UsersRepository
    {

        public IEnumerable<ApplicationUser> GetApplicationUsers()
        {
            IEnumerable<ApplicationUser> applicationUsers;


            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                applicationUsers = db.Users
                     .Include("Reservations")
                     .ToList();
            }

            return applicationUsers;
        }
        public ApplicationUser FindUserById(string id)
        {
            var user = new ApplicationUser();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException();
                }

                user = db.Users.Include("Reservations").Single(i => i.Id == id);
               

            }

            return user;
        }

        public void Edit(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Users.Attach(user); ;
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch { }
          

        }

        public IEnumerable<ApplicationUser> SearchUsers(string searchTerm)
        {
            IEnumerable<ApplicationUser> users;

            using (var db = new ApplicationDbContext())
            {
                users = db.Users.Where(user => user.Firstname.Contains(searchTerm) ||
                                    user.Lastname.Contains(searchTerm)||
                                     user.Email.Contains(searchTerm) ||
                                     user.UserName.Contains(searchTerm))
                              .Include("Reservations")
                              .ToList();
            }
           

            return users;
        }

    }
}