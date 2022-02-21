using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class Picture
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        public Picture(WebProgProject.Data.ApplicationDbContext context)
        {
            context = _context;
        }
        public Picture() { }
        [Key]
        public int id { get; set; }
        public string notes { get; set; }
        public string picPath { get; set; }
        public ICollection<PicturePerson> PicturePersons { get; set; }
        public List<Person> Persons
        {
            get {
                if (_context == null) return null;
                var res = from perpic in _context.PicturePerson
                          join per in _context.Person on perpic.PersonID equals per.id
                          where perpic.pictureID == this.id
                          select per;
                return res.ToList<Person>();
            }

        }
        public List<Cemetary> Cemetaries
        {
            get
            {
                if (_context == null) return null;
                var res = from cempic in _context.PictureCemetary
                          join cem in _context.Cemetary on cempic.CemetaryID equals cem.id
                          where cempic.pictureID == this.id
                          select cem;
                return res.ToList<Cemetary>();
            }

        }
        public List<Plot> Plots
        {
            get
            {
                if (_context == null) return null;
                var res = from plotpic in _context.PicturePlot
                          join plot in _context.Plot on plotpic.plotID equals plot.id
                          where plotpic.pictureID == this.id
                          select plot;
                return res.ToList<Plot>();
            }

        }

    }
}
