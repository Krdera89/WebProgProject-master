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
    public class DetailsModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public DetailsModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
