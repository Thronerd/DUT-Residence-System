﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<Models.Visitor> Visitors { get; set; }

        public System.Data.Entity.DbSet<Models.Booking> Bookings { get; set; }

        public System.Data.Entity.DbSet<Models.Rooms> Rooms { get; set; }

        public System.Data.Entity.DbSet<Models.Residence> Residences { get; set; }

        public System.Data.Entity.DbSet<Models.OtherUsers> OtherUsers { get; set; }

        public System.Data.Entity.DbSet<Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<Models.Funder> Funders { get; set; }

        public System.Data.Entity.DbSet<Models.Registraction> Registractions { get; set; }
    }
}