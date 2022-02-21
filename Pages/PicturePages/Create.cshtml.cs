using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PicturePages
{
    public class CreateModel : PageModel
    {
        private IHostingEnvironment _environment;
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public CreateModel(WebProgProject.Data.ApplicationDbContext context, IHostingEnvironment environment)
        {
            this._environment = environment;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Picture Picture { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public string type { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Picture.Add(Picture);
           
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads", Picture.id.ToString() + type);
            Picture.picPath = "/uploads/" + Picture.id.ToString() + type;
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
