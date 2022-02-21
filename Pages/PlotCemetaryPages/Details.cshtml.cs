using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PlotCemetaryPages
{
    public class DetailsModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public DetailsModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PlotCemetary PlotCemetary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlotCemetary = await _context.PlotCemetary
                .Include(p => p.cemetary)
                .Include(p => p.plot).FirstOrDefaultAsync(m => m.id == id);

            if (PlotCemetary == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
