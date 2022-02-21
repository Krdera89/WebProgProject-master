using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PersonPlotPages
{
    public class DetailsModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public DetailsModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PersonPlot PersonPlot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonPlot = await _context.PersonPlot
                .Include(p => p.person)
                .Include(p => p.plot).FirstOrDefaultAsync(m => m.id == id);

            if (PersonPlot == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
