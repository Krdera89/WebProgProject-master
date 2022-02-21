using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PicturePlotPages
{
    public class IndexModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public IndexModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PicturePlot> PicturePlot { get;set; }

        public async Task OnGetAsync()
        {
            PicturePlot = await _context.PicturePlot
                .Include(p => p.picture)
                .Include(p => p.plot).ToListAsync();
        }
    }
}
