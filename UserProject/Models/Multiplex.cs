using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class Multiplex
    {
        public int MultiplexId { get; set; }
        [Required]
        public string MultiplexName { get; set; }
        [Required]
        public string MultiplexDescription { get; set; }
        public string MultiplexImage { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public List<Auditorium> Auditoriums { get; set; }
    }
}
