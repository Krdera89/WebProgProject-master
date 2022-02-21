using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class PicturePlot
    {
        [Key]
        public int id { get; set; }
        public int plotID { get; set; }
        public Plot plot { get; set; }
        public int pictureID { get; set; }
        public Picture picture { get; set; }
    }
}
