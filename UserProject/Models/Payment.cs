using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminProject.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string StripePaymentId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BookingId { get; set; }
        public int UserDetailId { get; set; }
        
        public string Description { get; set; }
        public int Card { get; set; }
        public Booking Booking { get; set; }

    }
}
