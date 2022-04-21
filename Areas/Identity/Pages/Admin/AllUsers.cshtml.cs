using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebProgProject.Areas.Identity.Pages.Admin
{
    public class AllUsersModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        public List<IdentityUser> users;
        private readonly WebProgProject.Data.ApplicationDbContext _context;
        public AllUsersModel(UserManager<IdentityUser> usrMgr, WebProgProject.Data.ApplicationDbContext context)
        {
            userManager = usrMgr;
            _context = context;
        }
        public void OnGet()
        {
            users = userManager.Users.ToList<IdentityUser>();
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityUser user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        IdentityResult result = await userManager.DeleteAsync(user);
        //        if (result.Succeeded)
        //            return RedirectToPage("./Admin/AllUsers");

        //    }
        //    else
        //        ModelState.AddModelError("", "User Not Found");
        //    return ViewComponent("./Admin/AllUsers", userManager.Users);
        //}
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IdentityUser myUser = await userManager.FindByIdAsync(id);
            
            if(myUser != null)
            {
                await userManager.DeleteAsync(myUser);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./AllUsers");
        }


    }
}
