using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MiniTestProject.Areas.Admin.ViewComponents
{
    public class AdminOptions : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var user = c.Users.Where(x => x.UserName == username).FirstOrDefault();
            return View(user);

        }
    }
}
