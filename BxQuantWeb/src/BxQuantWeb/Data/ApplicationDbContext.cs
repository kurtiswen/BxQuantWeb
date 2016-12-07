using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BxQuantWeb.Models;

namespace BxQuantWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public class UserProfile
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public string Avatar { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }

            public string Location { get; set; }

            public string Description { get; set; }

        }
    }
}
