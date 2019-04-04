using System;
using System.Collections.Generic;

namespace UserSideProject.Models
{
    public partial class Movies
    {
        public Movies()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public double MoviePrice { get; set; }
        public int AuditoriumId { get; set; }

        public Auditoriums Auditorium { get; set; }
        public MovieDetails MovieDetails { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
