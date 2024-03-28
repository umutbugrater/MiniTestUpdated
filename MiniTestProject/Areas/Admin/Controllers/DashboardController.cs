using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniTestProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {
        private readonly IAnswerLineService _answerLineService;
        private readonly IQuestionService _questionService;
        Context c = new Context();

        public DashboardController(IAnswerLineService answerLineService, IQuestionService questionService)
        {
            _answerLineService = answerLineService;
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            var totalUser = c.Users.Count() - 1;//Admini kullanıcı sayısından çıkardım
            ViewBag.TotalUser = totalUser;
          
            var anketeKatılanlar = _answerLineService.TGetList().GroupBy(x => x.AppUserID).Count();
            ViewBag.AnketeKatılanlar = anketeKatılanlar;
            ViewBag.AnketeKatılmayanlar = totalUser - anketeKatılanlar;

            //Her bir soru cevaplanma
            var group = _answerLineService.TGetList().GroupBy(x => x.Question_ID).OrderBy(x=>x.Key).ToList();
            int[] cevaplayanCount = new int[group.Count];
            int[] soruId = new int[group.Count];
            int i = 0;
            foreach (var item in group)
            {
                cevaplayanCount[i] = item.GroupBy(x => x.AppUserID).ToList().Count();
                soruId[i] = item.Key;
                i++;
            }

            ViewBag.soruLeng = _questionService.TGetList().Count();

            var model = _questionService.TGetList();
            ViewBag.soruId = soruId;
            ViewBag.soruIdCount = soruId.Length;
            ViewBag.cevaplayanCount = cevaplayanCount;
            return View(model);
        }
    }
}
