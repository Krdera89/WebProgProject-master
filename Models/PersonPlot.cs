using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class PersonPlot
    {
        [Key]
        public int id { get; set; }
        public int plotID { get; set; }
        public Plot plot { get; set; }
        public int personID { get; set; }
        public Person person { get; set; }
    }
}
