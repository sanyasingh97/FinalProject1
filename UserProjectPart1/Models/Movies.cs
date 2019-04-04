using System;
using System.Collections.Generic;

namespace UserProjectPart1.Models
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
        public string MovieDescription { get; set; }
        public string MovieDuration { get; set; }
        public string MovieImage { get; set; }

        public Auditoriums Auditorium { get; set; }
        public MovieDetails MovieDetails { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
