using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MiniTestProject.Models;

namespace MiniTestProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public ProfileController(UserManager<AppUser> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Identity.Name;
            var values = await _userManager.FindByNameAsync(user);

            ViewBag.name = values.Name.ToUpper();
            ViewBag.surName = values.Surname.ToLower();
            ViewBag.image = values.ImageUrl;
            return View();
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> Index(List<IFormFile> postedFiles)
        {
            var user = User.Identity.Name;
            var values = await _userManager.FindByNameAsync(user);
            ViewBag.name = values.Name.ToUpper();
            ViewBag.surName = values.Surname.ToLower();
            ViewBag.image = values.ImageUrl;
            string wwwPath = _environment.WebRootPath;
            string contentPath = _environment.ContentRootPath;

            string path = Path.Combine(_environment.WebRootPath, "CVs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProfileEdit()
        {
            var user = User.Identity.Name;
            var values = await _userManager.FindByNameAsync(user);
            UserEditViewModel model = new UserEditViewModel();
            model.name = values.Name;
            model.surname = values.Surname;
            model.email = values.Email;
            model.imageurl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(UserEditViewModel p, IFormFile img)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (img != null)
            {
                string uzanti = Path.GetExtension(img.FileName);
                string resimAdi = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/UserImages/{resimAdi}");
                using var stream = new FileStream(path, FileMode.Create);
                img.CopyTo(stream);
                values.ImageUrl = resimAdi;
            }
            values.Name = p.name;
            values.Surname = p.surname;
            values.Email = p.email;
            if (!p.changePassword)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
                var result2 = await _userManager.UpdateAsync(values);
                return RedirectToAction("LogOut", "Login");

            }
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Profile");
        }
    }
}
