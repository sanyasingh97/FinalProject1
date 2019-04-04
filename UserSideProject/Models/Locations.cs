using System;
using System.Collections.Generic;

namespace UserSideProject.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Multiplexes = new HashSet<Multiplexes>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public ICollection<Multiplexes> Multiplexes { get; set; }
    }
}
