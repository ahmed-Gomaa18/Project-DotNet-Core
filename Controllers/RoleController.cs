using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ViewModel;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RoleController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel NewRole)
        {
            // Validate
            if(ModelState.IsValid == true)
            {
                // Map
                IdentityRole role = new IdentityRole() { Name = NewRole.RoleName };
                IdentityResult result = await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                
            }
            return View(NewRole);
        }

       
/*        public async Task<IActionResult> AssignAsAdmin()
        {
            string userName = User.Identity.Name;
            IdentityUser user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "Admin");
                return Content($"You Are Admin ya {user} Now.");
            }

            return Content("Error");
        }*/
    }
}
