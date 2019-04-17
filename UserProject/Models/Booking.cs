using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProject.Models;

namespace AdminProject.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public double BookingAmount { get; set; }
        public DateTime BookingDate { get; set; }
        public int UserDetailId { get; set; }
        public string ShowTiming { get; set; }
        public string AudiName { get; set; }
        public UserDetail UserDetail { get; set; }
        public Payment Payment { get; set; }


    }
}
