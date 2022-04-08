using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebProgProject.Models;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;


namespace WebProgProject.Pages
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(WebProgProject.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public PaginatedList<Person> persons { get; set; }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
        }
        //IQueryable<Person> personQ = from p in _context.Person select p;
        //int pageSize = 25;
        //Persons = await PaginatedList<Person>.CreateAsync(personQ.AsNoTracking(), pageIndex ?? 1, pageSize);
    }
}
