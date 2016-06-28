using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WellBellSecure.Models;

namespace WellBellSecure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
            //{
            //    b.Property<int>("Id")
            //        .ValueGeneratedOnAdd();

            //    b.Property<string>("ClaimType");

            //    b.Property<string>("ClaimValue");

            //    b.Property<string>("UserId")
            //        .IsRequired();

            //    b.HasKey("Id");

            //    b.HasIndex("UserId");

            //    b.ToTable("AspNetUserClaims");
            //});


            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Event>()
             .Map(map => {
                 map.Properties(p => new { p.Id, p.CalendarId, p.Title, p.Location, p.Description, p.Color });
                 map.ToTable("Events");
             })

             .Map(map => {
                 map.Properties(p => new { p.StartDateTimeUTC, p.EndDateTimeUTC, p.SeriesEndDateUTC, p.FreqType, p.FreqSubtype, p.FreqInterval });
                 map.ToTable("Schedules");
             });



        }
    }
}
