using System;
using System.Collections.Generic;

namespace UserProjectPart1.Models
{
    public partial class Auditoriums
    {
        public Auditoriums()
        {
            Movies = new HashSet<Movies>();
        }

        public int AuditoriumId { get; set; }
        public string AuditoriumName { get; set; }
        public string AuditoriumDescription { get; set; }
        public int Seats { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Time3 { get; set; }
        public int MultiplexId { get; set; }

        public Multiplexes Multiplex { get; set; }
        public ICollection<Movies> Movies { get; set; }
    }
}
