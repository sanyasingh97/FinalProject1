using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class MovieDetail
    {
        public int MovieDetailId { get; set; }
        public int MovieId { get; set; }
        public string Casting { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string MovieType { get; set; }
        public string MovieImage { get; set; }
        public string MovieDuration { get; set; }
        public Movie Movie { get; set; }
    }
}
