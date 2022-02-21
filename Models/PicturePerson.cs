using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class PicturePerson
    {
        [Key]
        public int id { get; set; }
        public int PersonID { get; set; }
        public Person person { get; set; }
        public int pictureID { get; set; }
        public Picture picture { get; set; }
    }
}
