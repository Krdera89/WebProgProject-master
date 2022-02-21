using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PictureCemetaryPages
{
    public class DeleteModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public DeleteModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PictureCemetary PictureCemetary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PictureCemetary = await _context.PictureCemetary
                .Include(p => p.cemetary)
                .Include(p => p.picture).FirstOrDefaultAsync(m => m.id == id);

            if (PictureCemetary == null)
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

            PictureCemetary = await _context.PictureCemetary.FindAsync(id);

            if (PictureCemetary != null)
            {
                _context.PictureCemetary.Remove(PictureCemetary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
