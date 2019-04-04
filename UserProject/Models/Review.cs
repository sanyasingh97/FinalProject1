using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserProject.Models;

namespace AdminProject.Models
{
    public class Review
    {
        [Column(Order = 0), Key, ForeignKey("UserDetail")]
        public int UserDetailId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Movie")]
        public int MovieId { get; set; }
        public string Comment { get; set; }
        public UserDetail UserDetail { get; set; }
        public Movie Movie { get; set; }
    }
}
