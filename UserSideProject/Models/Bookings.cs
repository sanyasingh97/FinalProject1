using System;
using System.Collections.Generic;

namespace UserSideProject.Models
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public int QtySeats { get; set; }
        public double BookingAmount { get; set; }
        public int UserDetailId { get; set; }
        public int MovieId { get; set; }

        public Movies Movie { get; set; }
        public UserDetails UserDetail { get; set; }
    }
}
