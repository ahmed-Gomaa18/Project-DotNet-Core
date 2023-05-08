using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ViewModel;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        // Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountViewModel newUser)
        {
            if(ModelState.IsValid == true) 
            {
                // Map to User
                IdentityUser user = new IdentityUser();
                user.UserName = newUser.UserName;
                user.Email = newUser.Email;

                // Create User
                IdentityResult result = await userManager.CreateAsync(user, newUser.Password);

                // Check If userManager Can Creat User Or Not
                if(result.Succeeded)
                {
                    // Create Cookie
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Instructor");
                }
                // Show Errors if can't Create New User
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(newUser);

        }

        // Login
        public IActionResult Login([FromQuery] string ReturnUrl="~/Home/Index")
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountViewModel loginUser, string ReturnUrl="~/Home/Index")
        {
            // Check Validation
            if (ModelState.IsValid == true)
            {
                // Get User By Name
                IdentityUser user = await userManager.FindByNameAsync(loginUser.UserName);
                // Check If User exist Or not
                if (user != null)
                {
                    // Chek If Password is Valid & Create Cookie 
                    Microsoft.AspNetCore.Identity.SignInResult result =  await signInManager.PasswordSignInAsync(user, loginUser.Password, isPersistent: loginUser.RememberMe,false);
                    // Check If Password is Valid
                    if (result.Succeeded)
                    {
                        // Redirect
                        return LocalRedirect(ReturnUrl != null ? ReturnUrl : "~/Home/Index");
                    }
                    else
                    {
                        // If Password is Not Valid Add Error To ModelState
                        ModelState.AddModelError("UserName", "Invalid UserName OR Password");
                    }
                }
                else // If User Exist Add Error To ModelState
                {
                    ModelState.AddModelError("UserName", "Invalid UserName OR Password");
                }
            }
            return View(loginUser);
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
