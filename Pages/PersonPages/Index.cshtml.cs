using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PersonPages
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public IndexModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        
        public string LNameSort { get; set; }
        public string FNameSort { get; set; }
        public string BirthDateSort { get; set; }
        public string DeathDateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Person> People { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
           
            LNameSort = String.IsNullOrEmpty(sortOrder) ? "Lname_desc" : "";
            FNameSort = String.IsNullOrEmpty(sortOrder) ? "Fname_desc" : "";
            BirthDateSort = sortOrder == "Birthdate" ? "Birthdate_desc" : "Birthdate";
            DeathDateSort = sortOrder == "DeathDate" ? "date_desc" : "DeathDate";

            IQueryable<Person> personIQ = from s in _context.Person
                                          select s;

            CurrentFilter = searchString;

            if(!String.IsNullOrEmpty(searchString))
            {
                personIQ = personIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "Lname_desc":
                    personIQ = personIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Fname_desc":
                    personIQ = personIQ.OrderByDescending(s => s.FirstName);
                    break;
                case "Birthdate":
                    personIQ = personIQ.OrderBy(s => s.DateOfBirth);
                    break;
                case "Birthdate_desc":
                    personIQ = personIQ.OrderByDescending(s => s.DateOfBirth);
                    break;
                case "DeathDate":
                    personIQ = personIQ.OrderBy(s => s.AgeAtDeath);
                    break;
                case "date_desc":
                    personIQ = personIQ.OrderByDescending(s => s.AgeAtDeath);
                    break;
                default:
                    personIQ = personIQ.OrderBy(s => s.Name);
                    break;
            }

            People = await personIQ.AsNoTracking().ToListAsync();
        }
    }
}
