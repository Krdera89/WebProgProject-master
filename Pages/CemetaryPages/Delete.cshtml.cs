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
    public class DeleteModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public DeleteModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cemetary Cemetary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cemetary = await _context.Cemetary.FirstOrDefaultAsync(m => m.id == id);

            if (Cemetary == null)
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

            Cemetary = await _context.Cemetary.FindAsync(id);

            if (Cemetary != null)
            {
                _context.Cemetary.Remove(Cemetary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
