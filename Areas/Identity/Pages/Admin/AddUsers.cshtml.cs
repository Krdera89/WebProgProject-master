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
        public void OnGet()
        {
        }
    }
}
