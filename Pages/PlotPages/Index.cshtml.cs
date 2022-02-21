using System;
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
    public class IndexModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public IndexModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string PlotSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Plot> Plot { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            Plot = await _context.Plot.ToListAsync();

            PlotSort = String.IsNullOrEmpty(sortOrder) ? "plot_desc" : "";


            IQueryable<Plot> plotIQ = from p in _context.Plot
                                              select p;

            CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                plotIQ = plotIQ.Where(s => s.plotNumber.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "plot_desc":
                    plotIQ = plotIQ.OrderByDescending(p => p.plotNumber);
                    break;
                default:
                    plotIQ = plotIQ.OrderBy(p => p.plotNumber);
                    break;
            }

            Plot = await plotIQ.AsNoTracking().ToListAsync();
        }
    }
}
