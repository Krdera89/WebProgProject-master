using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class Cemetary
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        public Cemetary(WebProgProject.Data.ApplicationDbContext context)
        {
            context = _context;
        }
        public Cemetary() { }

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public ICollection<PlotCemetary> PlotCemetaries { get; set; }
        public List<Picture> Pictures
        {
            get
            {
                if (_context == null) return null;
                var res = from cempic in _context.PictureCemetary
                          join pic in _context.Picture on cempic.pictureID equals pic.id
                          where cempic.CemetaryID == this.id
                          select pic;
                return res.ToList<Picture>();

            }

        }

        public List<Plot> Plots
        {
            get
            {
                if (_context == null) return null;
                var res = from plotcem in _context.PlotCemetary
                          join plot in _context.Plot on plotcem.plotID equals plot.id
                          where plotcem.CemetaryID == this.id
                          select plot;
                return res.ToList<Plot>();
            }

        }
    }
}
