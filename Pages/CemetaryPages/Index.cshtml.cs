using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.CemetaryPages
{
    public class IndexModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public IndexModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Cemetary> Cemetary { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            CurrentFilter = searchString;

            IQueryable<Cemetary> CemetaryIQ = from c in _context.Cemetary
                                              select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                CemetaryIQ = CemetaryIQ.Where(s => s.name.Contains(searchString)
                                       || s.address.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    CemetaryIQ = CemetaryIQ.OrderByDescending(c => c.name);
                    break;
                default:
                    CemetaryIQ = CemetaryIQ.OrderBy(c => c.name);
                    break;
            }

            Cemetary = await CemetaryIQ.AsNoTracking().ToListAsync();
        }
    }
}
