using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MiniTestProject.Models;

namespace MiniTestProject.Controllers
{
    public class QuestionAnswerController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _questionOptionService;
        private readonly IAnswerLineService _answerLineService;
        Context c = new Context();

        public QuestionAnswerController(IQuestionService questionService, IQuestionOptionService questionOptionService, IAnswerLineService answerLineService)
        {
            _questionService = questionService;
            _questionOptionService = questionOptionService;
            _answerLineService = answerLineService;
        }


        public IActionResult Index()
        {
            var questions = _questionService.TGetList();
            ViewBag.options = _questionOptionService.TGetList(); ;
            return View(questions);
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            var user = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == user).Select(x => x.Id).FirstOrDefault();

            string[] keys = new string[form.Count()];
            string[] values = new string[form.Count()];
            int i = 0;
            foreach (var item in form)
            {
                keys[i] = item.Key;
                values[i] = item.Value;
                i++;

            }
            string[] yeniKey = new string[keys.Length - 1];
            Array.Copy(keys, yeniKey, keys.Length - 1);
            keys = yeniKey;
            string[] yeniValue = new string[values.Length - 1];
            Array.Copy(values, yeniValue, values.Length - 1);
            values = yeniValue;

            List<string> liste = new List<string>(values);
            List<string> liste2 = new List<string>(keys);
            //inputta yazılmayan değerler boş gönderiliyor. boş değerleri almaması için yapıldı
            for (int k = 0; k < values.Length; k++)
            {
                if (values[k] == " ")
                {
                    liste.Remove(values[k]);
                    liste2.Remove(keys[k]);
                }
            }
            values = liste.ToArray();
            keys = liste2.ToArray();
            for (int j = 0; j < keys.Length; j++)
            {
                int soruId = Convert.ToInt32(keys[j]);
                var model = _answerLineService.TGetList().FirstOrDefault(x => x.Question_ID == soruId && x.AppUserID == userid);
                if (model != null)
                {
                    model.Answer = values[j];
                    _answerLineService.TUpdate(model);
                }
                else
                {
                    SaveData(values[j], soruId, userid);
                }
            }

            return RedirectToAction("Index", "Profile");
        }

        public void SaveData(string answer, int questionID, int userID)
        {
            _answerLineService.TAdd(new AnswerLine
            {
                Answer = answer,
                Question_ID = questionID,
                AppUserID = userID
            });
        }
    }
}
