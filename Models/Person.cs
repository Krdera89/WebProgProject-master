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
        [Display(Name = "Census Records")]
        public string CensusRecords{get;set;}
        public string Upload { get; set; }
        [Display(Name = "Maiden Name")]
        public string MaidenName { get; set; }
        public string Name { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Spouse { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public string Siblings { get; set; }
        public string Title { get; set; }
        public string Job { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Date Of Marriage")]
        public DateTime DateOfMarriage { get; set; } //Date of marriage

        [Display(Name = "Age At Death")]
        public DateTime AgeAtDeath { get; set; }
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }
        [Display(Name = "Death Place")]
        public string DeathPlace { get; set; }
        public string Profession { get; set; }
        [Display(Name = "Death Cause")]
        public string DeathCause { get; set; }

        [Display(Name = "Date Of Death")]
        public DateTime DateOfDeath { get; set; }
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

