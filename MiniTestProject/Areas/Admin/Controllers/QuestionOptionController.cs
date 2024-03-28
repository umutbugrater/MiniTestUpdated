using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniTestProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class QuestionOptionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _questionOptionService;

        public QuestionOptionController(IQuestionService questionService, IQuestionOptionService questionOptionService)
        {
            _questionService = questionService;
            _questionOptionService = questionOptionService;
        }
       
        public IActionResult Index(int id)
        {
            ViewBag.soru = _questionService.TGetById(id).QuestionLine;
            ViewBag.i = id;
            var values = _questionOptionService.TGetList(x => x.Question_ID == id);
            return View(values);
        }

        [HttpGet]
        public IActionResult QuestionOptionsAdd(int id)
        {
            ViewBag.soru = _questionService.TGetById(id).QuestionLine;
            return View();
        }
        [HttpPost]
        public IActionResult QuestionOptionsAdd(QuestionOption p,int id)
        {
            QuestionOption option = new QuestionOption()
            {
                OptionDescription = p.OptionDescription,
                Question_ID = id
            };
            _questionOptionService.TAdd(option);
            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult QuestionOptionsDelete(int id)
        {
            var value = _questionOptionService.TGetById(id);
            _questionOptionService.TDelete(value);
            return RedirectToAction("Index", new { id = value.Question_ID });
        }

        [HttpGet]
        public IActionResult QuestionOptionsUpdate(int id)
        {
            var value = _questionOptionService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult QuestionOptionsUpdate(QuestionOption questionOption)
        {
            _questionOptionService.TUpdate(questionOption);
            return RedirectToAction("Index", new { id = questionOption.Question_ID });
        }
    }
}
