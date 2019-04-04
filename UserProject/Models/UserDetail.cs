using AdminProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class UserDetail
    {
        public int UserDetailID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long ContactNo { get; set; }
        public string UserName { get; set; }
        public List<Booking> Bookings { get; set; }
        public Review Reviews { get; set; }
    }
}
