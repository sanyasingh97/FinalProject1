using AdminProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{


    public class FinalProjectDataDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Multiplex> Multiplexes { get; set; }

        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("Data Source=TRD-507;Initial Catalog=a1;Integrated Security=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetail>(
                build =>
                {
                    build.HasKey(t => new { t.BookingId, t.MovieId });

                });
            modelBuilder.Entity<Review>(
                   build =>
                   {
                       build.HasKey(t => new { t.UserDetailId, t.MovieId });
                   });

            base.OnModelCreating(modelBuilder);
            //{
            //    modelBuilder.Entity<MovieDetail>()
            //        .HasOne(b => b.Movies)
            //        .WithOne(p => p.MovieDetails)
            //        .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
    