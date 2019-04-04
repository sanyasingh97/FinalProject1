using System;
using System.Collections.Generic;

namespace UserSideProject.Models
{
    public partial class Multiplexes
    {
        public Multiplexes()
        {
            Auditoriums = new HashSet<Auditoriums>();
        }

        public int MultiplexId { get; set; }
        public string MultiplexName { get; set; }
        public string MultiplexDescription { get; set; }
        public int LocationId { get; set; }

        public Locations Location { get; set; }
        public ICollection<Auditoriums> Auditoriums { get; set; }
    }
}
