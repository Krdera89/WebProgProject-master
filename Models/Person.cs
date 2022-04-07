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
        public int SpouseID { get; set; }
        [Display(Name = "Census Records")]
        public string CensusRecords{get;set;}
        [Display(Name = "Tombstone Image")]
        public string Tombstone { get; set; }
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
        [Display(Name = "Mother")]
        public string Mother { get; set; }
        [Display(Name = "Father")]
        public string Father { get; set; }
        public string Siblings { get; set; }
        [Display(Name = "Biological children")]
        public string Children { get; set; }

        [Display(Name ="Paternal Grandfather")]
        public string PatGpa { get; set; }
        [Display(Name = "Paternal Grandmother")]
        public string PatGma { get; set; }
        [Display(Name = "Maternal Grandfather")]
        public string MatGpa { get; set; }
        [Display(Name = "Maternal Grandmother")]
        public string MatGma { get; set; }
        [Display(Name = "Paternal Great Grandfather")]
        public string PatGreatGpa { get; set; }
        [Display(Name = "Paternal Great Grandmother")]
        public string PatGreatGma { get; set; }
        [Display(Name = "Maternal Great Grandfather")]
        public string MatGreatGpa { get; set; }
        [Display(Name = "Maternal Great Grandmother")]
        public string MatGreatGma { get; set; }
        [Display(Name = "Burial Year")]
        public string BurialYear { get; set; }
        [Display(Name = "Census Book Number")]
        public string CensusBookNumber { get; set; }
        [Display(Name = "Census Page Number")]
        public string CensusPageNumber { get; set; }
        [Display(Name = "Census Entry Number")]
        public string CensusEntryNumber { get; set; }
        [Display(Name = "Orientation In Lot")]
        public string OrientationInLot { get; set; }
        [Display(Name = "Lot Number")]
        public string LotNumber { get; set; }
        [Display(Name = "Mausoleum Corridor")]
        public string MausCorridor { get; set; }
        [Display(Name = "Mausoleum Tier")]
        public string MausTier { get; set; }
        [Display(Name = "Grave Number in Crypt")]
        public string GraveNumInCrypt { get; set; }
        public string Street { get; set; }
        [Display(Name = "Section Number")]
        public string SectionNum { get; set; }
        [Display(Name = "Immigration Year")]
        public string ImmigrationYear { get; set; }
        [Display(Name = "GPS Reading at Gravesite")]
        public string GPSGravesite { get; set; }


        //[Display(Name = "Maternal Grand Mother")]
        //public string GrandMother { get; set; }
        //[Display(Name = " Paternal Grand Father")]
        //public string GrandFather { get; set; }
        //[Display(Name = " Maternal Great Grand Mother")]
        //public string GreatGrandMother { get; set; }
        //[Display(Name = "Paternal Great Grand Father")]
        //public string GreatGrandFather { get; set; }



        public string Title { get; set; }
        public string Job { get; set; }
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }
        [Display(Name = "Marriage")]
        public string DateOfMarriage { get; set; } //Date of marriage

        [Display(Name = "Age At Death")]
        public string AgeAtDeath { get; set; }
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }
        [Display(Name = "Death Place")]
        public string DeathPlace { get; set; }
        //public string Profession { get; set; }
        [Display(Name = "Death Cause")]
        public string DeathCause { get; set; }

        [Display(Name = "Date Of Death")]
        public string DateOfDeath { get; set; }
        // public Person spouse { get; set; }
        // public Person mother { get; set; }
        // public Person father { get; set; }
        [Display(Name = "Date Of Burial")]
        public string BurialDate { get; set; }
        [Display(Name = "Gender")]
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

