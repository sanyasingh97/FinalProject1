using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserProject.Models;

namespace AdminProject.Models
{
    public class BookingDetail
    {
        [Column(Order = 0), Key, ForeignKey("Booking")]
        public int BookingId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Movie")]
        public int MovieId { get; set; }

        public int QtySeats { get; set; }
        public Booking Booking { get; set; }
        public Movie Movie { get; set; }

    }
}
