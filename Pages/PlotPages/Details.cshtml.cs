﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PlotPages
{
    public class DetailsModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public DetailsModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Plot Plot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plot = await _context.Plot.FirstOrDefaultAsync(m => m.id == id);

            if (Plot == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
