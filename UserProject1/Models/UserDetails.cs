﻿using System;
using System.Collections.Generic;

namespace UserProject1.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int UserDetailId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long ContactNo { get; set; }
        public string UserName { get; set; }

        public Reviews Reviews { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
