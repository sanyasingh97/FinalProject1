using AdminProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public double MoviePrice { get; set; }
        public string MovieImage { get; set; }
        public string MovieDuration { get; set; }
        public string MovieDescription { get; set; }
        public int MultiplexId { get; set; }
        public DateTime MovieDate { get; set; }
        public Multiplex Multiplex { get; set; }
        public MovieDetail MovieDetail { get; set; }
        public Review Reviews { get; set; }

        //public List<Booking> Bookings { get; set; }



    }
}
