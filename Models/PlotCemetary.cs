using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class PlotCemetary
    {
        [Key]
        public int id { get; set; }
        public int CemetaryID { get; set; }
        public Cemetary cemetary { get; set; }
        public int plotID { get; set; }
        public Plot plot { get; set; }
    }
}