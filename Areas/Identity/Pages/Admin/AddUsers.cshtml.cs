using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public AddUsersModel(UserManager<IdentityUser> usrMgr)
        {
            userManager = usrMgr;
        }
        [BindProperty]
        [Required]
        public string UserName { get; set; }
        //[BindProperty]
        //public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (UserName != null && Password != null)
            {
                IdentityUser newUser = new IdentityUser();
                newUser.UserName = UserName;
                //newUser.PasswordHash = Password;
                //newUser.Email = Email;
                newUser.EmailConfirmed = true;
                IdentityResult result = await userManager.CreateAsync(newUser, Password);
                
            }
            return RedirectToPage("./AllUsers");
        }
    }
}
