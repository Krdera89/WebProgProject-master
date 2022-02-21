using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PlotCemetaryPages
{
    public class CreateModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public CreateModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CemetaryID"] = new SelectList(_context.Cemetary, "id", "id");
        ViewData["plotID"] = new SelectList(_context.Plot, "id", "id");
            return Page();
        }

        [BindProperty]
        public PlotCemetary PlotCemetary { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlotCemetary.Add(PlotCemetary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
