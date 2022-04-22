﻿using System;
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
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PersonPages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        //public FileUploadModel(IHostingEnvironment environment)
        //{
        //    _environment = environment;
        //}
        public EditModel(WebProgProject.Data.ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.id == id);

            if (Person == null)
            {
                return NotFound();
            }
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

            //if (Person.Upload != null && Person.Upload != "")
            //{
            
            

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
            
            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.id))
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

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.id == id);
        }
    }
}
