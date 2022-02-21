using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgProject.Models
{
    public class Person
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        public Person(WebProgProject.Data.ApplicationDbContext context)
        {
            context = _context;
        }
        public Person() { }
        [Key]
        public int id { get; set; }
        public string Upload { get; set; }
        public string MaidenName { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Job { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DODeath { get; set; }
        public string BirthPlace { get; set; }
        public string DeathPlace { get; set; }
        public string Profession { get; set; }
        public string DeathCause { get; set; }
        // public Person spouse { get; set; }
        // public Person mother { get; set; }
        // public Person father { get; set; }
        public string gender { get; set; }
        public List<Person> survivedBy = new List<Person>();
        public List<Person> children = new List<Person>();
        public string contactPhone { get; set; }
        public string contactAddress { get; set; }
        public string contactEmail { get; set; }
        public int PlotID { get; set; }
        public Plot MyPlot { get; set; }
        public string notes { get; set; }
        public ICollection<PicturePerson> PicturePersons { get; set; }
        public List<Picture> Pictures
        {
            get
            {
                if (_context == null) return null;
                var res = from perpic in _context.PicturePerson
                          join pic in _context.Picture on perpic.pictureID equals pic.id
                          where perpic.PersonID == this.id
                          select pic;
                return res.ToList<Picture>();

            }

        }

        public List<Plot> Plots
        {
            get
            {
                if (_context == null) return null;
                var res = from perplot in _context.PersonPlot
                          join plot in _context.Plot on perplot.plotID equals plot.id
                          where perplot.personID == this.id
                          select plot;
                return res.ToList<Plot>();

            }

        }

    }
}

