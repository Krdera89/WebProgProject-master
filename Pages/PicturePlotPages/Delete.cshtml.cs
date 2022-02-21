using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PicturePlotPages
{
    public class DeleteModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public DeleteModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PicturePlot PicturePlot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PicturePlot = await _context.PicturePlot
                .Include(p => p.picture)
                .Include(p => p.plot).FirstOrDefaultAsync(m => m.id == id);

            if (PicturePlot == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PicturePlot = await _context.PicturePlot.FindAsync(id);

            if (PicturePlot != null)
            {
                _context.PicturePlot.Remove(PicturePlot);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
