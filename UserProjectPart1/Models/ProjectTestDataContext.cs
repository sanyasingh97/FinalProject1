using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserProjectPart1.Models
{
    public partial class ProjectTestDataContext : DbContext
    {
        public ProjectTestDataContext()
        {
        }

        public ProjectTestDataContext(DbContextOptions<ProjectTestDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditoriums> Auditoriums { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MovieDetails> MovieDetails { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Multiplexes> Multiplexes { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-506;Database=ProjectTestData; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditoriums>(entity =>
            {
                entity.HasKey(e => e.AuditoriumId);

                entity.HasIndex(e => e.MultiplexId);

                entity.HasOne(d => d.Multiplex)
                    .WithMany(p => p.Auditoriums)
                    .HasForeignKey(d => d.MultiplexId);
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.HasIndex(e => e.MovieId);

                entity.HasIndex(e => e.UserDetailId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.MovieId);

                entity.HasOne(d => d.UserDetail)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserDetailId);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId);
            });

            modelBuilder.Entity<MovieDetails>(entity =>
            {
                entity.HasKey(e => e.MovieDetailId);

                entity.HasIndex(e => e.MovieId)
                    .IsUnique();

                entity.HasOne(d => d.Movie)
                    .WithOne(p => p.MovieDetails)
                    .HasForeignKey<MovieDetails>(d => d.MovieId);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.HasIndex(e => e.AuditoriumId);

                entity.HasOne(d => d.Auditorium)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.AuditoriumId);
            });

            modelBuilder.Entity<Multiplexes>(entity =>
            {
                entity.HasKey(e => e.MultiplexId);

                entity.HasIndex(e => e.LocationId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Multiplexes)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserDetailId);

                entity.Property(e => e.UserDetailId).HasColumnName("UserDetailID");
            });
        }
    }
}
