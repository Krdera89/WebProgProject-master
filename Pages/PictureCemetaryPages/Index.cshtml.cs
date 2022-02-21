using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebProgProject.Data;
using WebProgProject.Models;

namespace WebProgProject.Pages.PictureCemetaryPages
{
    public class IndexModel : PageModel
    {
        private readonly WebProgProject.Data.ApplicationDbContext _context;

        public IndexModel(WebProgProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PictureCemetary> PictureCemetary { get;set; }

        public async Task OnGetAsync()
        {
            PictureCemetary = await _context.PictureCemetary
                .Include(p => p.cemetary)
                .Include(p => p.picture).ToListAsync();
        }
    }
}
