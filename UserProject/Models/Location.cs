using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        public string LocationName { get; set; }
        public string LocationImage { get; set; }
        public List<Multiplex> Multiplexes { get; set; }
    }
}