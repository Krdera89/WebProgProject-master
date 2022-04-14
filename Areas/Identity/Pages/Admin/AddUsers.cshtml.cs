using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebProgProject.Areas.Identity.Pages.Admin
{
    public class AddUsersModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        public void AddUserModel(UserManager<IdentityUser> usrMgr)
        {
            userManager = usrMgr;
        }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (UserName != null && Email != null)
            {
                IdentityUser newUser = new IdentityUser();
                newUser.UserName = UserName;
                newUser.Email = Email;
                IdentityResult result = await userManager.CreateAsync(newUser);
            }
            return RedirectToPage("./Users");
        }
    }
}
