using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelProctors.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength (50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength (50)]
        public string Lastname { get; set; }
        [Phone]
        [Required]
        public string Telephone { get; set; }
        [NotMapped]
        public string FullName {
            get { return Firstname + " " + Lastname; }
        }

        public virtual ICollection <Reservation> Reservations { get; set; }
        



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<AmenitiesPerRoom> Amenities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                       .HasRequired(i => i.Room)
                       .WithMany(a => a.Reservations)
                       .HasForeignKey(i => i.RoomId)
                       .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                     .HasRequired(i => i.Amenities)
                     .WithMany(a => a.Rooms)
                     .HasForeignKey(i => i.AmenitiesId)
                     .WillCascadeOnDelete(false);



            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("HotelProctors", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}