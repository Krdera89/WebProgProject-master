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

namespace WebProgProject.Pages.PicturePersonPages
{
    public class EditModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public EditModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PicturePerson PicturePerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PicturePerson = await _context.PicturePerson
                .Include(p => p.person)
                .Include(p => p.picture).FirstOrDefaultAsync(m => m.id == id);

            if (PicturePerson == null)
            {
                return NotFound();
            }
           ViewData["PersonID"] = new SelectList(_context.Person, "id", "id");
           ViewData["pictureID"] = new SelectList(_context.Picture, "id", "id");
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

            _context.Attach(PicturePerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PicturePersonExists(PicturePerson.id))
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

        private bool PicturePersonExists(int id)
        {
            return _context.PicturePerson.Any(e => e.id == id);
        }
    }
}
