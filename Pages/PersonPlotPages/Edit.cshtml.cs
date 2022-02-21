using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PersonPlotPages
{
    public class EditModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public EditModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["personID"] = new SelectList(_context.Person, "id", "id");
           ViewData["plotID"] = new SelectList(_context.Plot, "id", "id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonPlot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonPlotExists(PersonPlot.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonPlotExists(int id)
        {
            return _context.PersonPlot.Any(e => e.id == id);
        }
    }
}
