using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PersonPages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public CreateModel(WebProgProject.Data.ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public string type { get; set; }
        //[BindProperty]
        //public string uploadimage { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public IFormFile TombstoneUpload { get; set; }
        [BindProperty]
        public Picture pic { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Upload != null)
            {
                var fileUpload = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads", Person.id.ToString() + type);
                using (var fileStream = new FileStream(fileUpload, FileMode.Create))
                {

                    await Upload.CopyToAsync(fileStream);
                    Person.Upload = Path.GetFileName(fileUpload);

                }
            }
            else
            {
                Person.Upload = Person.id.ToString() + type;
            }


            if (TombstoneUpload != null)
            {
                var fileTombstone = Path.Combine(_environment.ContentRootPath, "wwwroot/uploads", "tombstone" + Person.id.ToString() + type);
                using (var filestream = new FileStream(fileTombstone, FileMode.Create))
                {

                    await TombstoneUpload.CopyToAsync(filestream);
                    Person.Tombstone = Path.GetFileName(fileTombstone);

                }
            }

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
