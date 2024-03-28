using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MiniTestProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser, IFormFile img)
        {

            if (img != null)
            {
                string uzanti = Path.GetExtension(img.FileName);
                string resimAdi = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/UserImages/{resimAdi}");
                using var stream = new FileStream(path, FileMode.Create);
                img.CopyTo(stream);
                appUser.ImageUrl = resimAdi;

                //identity kütüphanesinde, şifre metot çağrılırken giriliyor
                var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);
                await _userManager.AddToRoleAsync(appUser, "Member");

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                appUser.ImageUrl = "Nophoto.jpg";
                //identity kütüphanesinde, şifre metot çağrılırken giriliyor
                var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);
                await _userManager.AddToRoleAsync(appUser, "Member");
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(appUser);
        }

    }
}
