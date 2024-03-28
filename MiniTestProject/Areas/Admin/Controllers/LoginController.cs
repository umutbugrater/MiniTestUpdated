using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MiniTestProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser user)
        {

            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View(user);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
