using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniTestProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionTypeService _questionTypeService;

        public QuestionController(IQuestionService questionService, IQuestionTypeService questionTypeService)
        {
            _questionService = questionService;
            _questionTypeService = questionTypeService;
        }

        public IActionResult Index()
        {
            var values = _questionService.GetQuestionsWithQuestionType();
            return View(values);
        }

        public IActionResult QuestionAdd()
        {
            List<SelectListItem> questionTypes = new List<SelectListItem>();
            questionTypes.Add(new SelectListItem
            {
                Text = "Bir Soru Türü seçiniz..",
                Value = null
            });
            foreach (var item in _questionTypeService.TGetList())
            {
                questionTypes.Add(new SelectListItem
                {
                    Text = item.QuestionTypeName,
                    Value = item.QuestionTypeID.ToString()
                });
            }
            ViewBag.QuestionTypes = questionTypes;
            return View();
        }

        [HttpPost]
        public IActionResult QuestionAdd(Question p)
        {
            p.CreateDate = Convert.ToDateTime(DateTime.Now);
            _questionService.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult QuestionDelete(int id)
        {
            var value = _questionService.TGetById(id);
            _questionService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult QuestionEdit(int id)
        {
            List<SelectListItem> questionTypes = new List<SelectListItem>();
            foreach (var item in _questionTypeService.TGetList())
            {
                questionTypes.Add(new SelectListItem
                {
                    Text = item.QuestionTypeName,
                    Value = item.QuestionTypeID.ToString()
                });
            }
            ViewBag.QuestionTypes = questionTypes;
            var value = _questionService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult QuestionEdit(Question p)
        {
            p.CreateDate = DateTime.Now;
            _questionService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
