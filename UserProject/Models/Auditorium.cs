using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class Auditorium
    {
        public int AuditoriumId { get; set; }
        public string AuditoriumName { get; set; }
        public string AuditoriumDescription { get; set; }
        public int Seats { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Time3 { get; set; }
        public int MultiplexId { get; set; }
        public Multiplex Multiplex { get; set; }
      
    }
}
