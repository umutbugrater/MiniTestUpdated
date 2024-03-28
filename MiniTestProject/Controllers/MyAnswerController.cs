using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MiniTestProject.Controllers
{
    public class MyAnswerController : Controller
    {
        private readonly IAnswerLineService _answerLineService;
        Context c = new Context();

        public MyAnswerController(IAnswerLineService answerLineService)
        {
            _answerLineService = answerLineService;
        }

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var userId = c.Users.Where(x=>x.UserName == username).FirstOrDefault().Id;
            var model = _answerLineService.TAnswerListWithQuestion().Where(x => x.AppUserID == userId);
            return View(model);
        }
    }
}
