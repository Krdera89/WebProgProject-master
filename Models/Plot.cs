using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class Plot
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        public Plot(WebProgProject.Data.ApplicationDbContext context)
        {
            context = _context;
        }
        public Plot() { }
        [Key]
        public int id { get; set; }
        public string plotNumber { get; set; }
        public string location { get; set; }
        public string notes { get; set; }
        public int CemID { get; set; }
       // public Cemetary MyCem { get; set; }
        public ICollection<PlotCemetary> PlotCemetaries { get; set; }
        public List<Picture> Pictures
        {
            get
            {
                if (_context == null) return null;
                var res = from plotpic in _context.PicturePlot
                          join pic in _context.Picture on plotpic.pictureID equals pic.id
                          where plotpic.plotID == this.id
                          select pic;
                return res.ToList<Picture>();

            }

        }

        public List<Cemetary> Cemetaries
        {
            get
            {
                if (_context == null) return null;
                var res = from plotcem in _context.PlotCemetary
                          join cem in _context.Cemetary on plotcem.CemetaryID equals cem.id
                          where plotcem.plotID == this.id
                          select cem;
                return res.ToList<Cemetary>();
            }

        }
    }
}
