namespace HotelProctors.Migrations
{
    using HotelProctors.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelProctors.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelProctors.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            context.Reservations.AddOrUpdate(x => x.Id,
            new Reservation() { ArrivalDate = new DateTime(2020, 05, 05), DepartureDate = new DateTime(2020, 05, 07), RoomId = 43, UserId = "d5d36d9d-b1f1-4e07-b85b-b44c065b03b2" });


            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);
            }

            if (!context.Users.Any(user => user.UserName == "admin@proctors.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@proctors.com",
                    Email = "admin@proctors.com",
                    Firstname = "Hotel",
                    Lastname = "Proctors",
                    Telephone= "6936347638"

                };

                var result = userManager.Create(user, "!Admin123");

                if (result.Succeeded)
                {
                    var admin = context.Users.SingleOrDefault(i => i.UserName == "admin@gighub.com");
                    userManager.AddToRoles(admin.Id, "Administrator", "User");
                }

                
                   
                    
                
            }

            context.Reservations.AddOrUpdate(x => x.Id,
            new Reservation() { ArrivalDate = new DateTime(2020, 05, 05), DepartureDate = new DateTime(2020, 05, 07), RoomId = 48, UserId = "d5d36d9d-b1f1-4e07-b85b-b44c065b03b2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 01, 22), DepartureDate = new DateTime(2020, 01, 25), RoomId = 44, UserId = "80e8208c-f876-4a00-abed-82a62b64f4d2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 01, 25), DepartureDate = new DateTime(2020, 01, 30), RoomId = 47, UserId = "01a63431-5d9e-477e-89ab-3cb77463ccd1" },
            new Reservation() { ArrivalDate = new DateTime(2020, 03, 25), DepartureDate = new DateTime(2020, 03, 30), RoomId = 48, UserId = "01a63431-5d9e-477e-89ab-3cb77463ccd1" },
            new Reservation() { ArrivalDate = new DateTime(2020, 02, 10), DepartureDate = new DateTime(2020, 02, 15), RoomId = 45, UserId = "01a63431-5d9e-477e-89ab-3cb77463ccd1" },
            new Reservation() { ArrivalDate = new DateTime(2020, 04, 18), DepartureDate = new DateTime(2020, 04, 25), RoomId = 45, UserId = "80e8208c-f876-4a00-abed-82a62b64f4d2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 06, 18), DepartureDate = new DateTime(2020, 06, 22), RoomId = 46, UserId = "80e8208c-f876-4a00-abed-82a62b64f4d2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 06, 26), DepartureDate = new DateTime(2020, 06, 29), RoomId = 49, UserId = "80e8208c-f876-4a00-abed-82a62b64f4d2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 05, 26), DepartureDate = new DateTime(2020, 05, 29), RoomId = 44, UserId = "80e8208c-f876-4a00-abed-82a62b64f4d2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 05, 26), DepartureDate = new DateTime(2020, 05, 29), RoomId = 44, UserId = "d5d36d9d-b1f1-4e07-b85b-b44c065b03b2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 03, 06), DepartureDate = new DateTime(2020, 03, 09), RoomId = 48, UserId = "d5d36d9d-b1f1-4e07-b85b-b44c065b03b2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 03, 06), DepartureDate = new DateTime(2020, 03, 09), RoomId = 49, UserId = "80e8208c-f876-4a00-abed-82a62b64f4d2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 09, 01), DepartureDate = new DateTime(2020, 09, 10), RoomId = 47, UserId = "80e8208c-f876-4a00-abed-82a62b64f4d2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 09, 05), DepartureDate = new DateTime(2020, 09, 12), RoomId = 48, UserId = "d5d36d9d-b1f1-4e07-b85b-b44c065b03b2" },
            new Reservation() { ArrivalDate = new DateTime(2020, 10, 05), DepartureDate = new DateTime(2020, 10, 12), RoomId = 45, UserId = "01a63431-5d9e-477e-89ab-3cb77463ccd1" },
            new Reservation() { ArrivalDate = new DateTime(2020, 10, 05), DepartureDate = new DateTime(2020, 10, 12), RoomId = 45, UserId = "d5d36d9d-b1f1-4e07-b85b-b44c065b03b2" }

            );

        }


    }
}
