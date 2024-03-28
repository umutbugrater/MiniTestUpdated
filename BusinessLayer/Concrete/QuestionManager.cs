using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public List<Question> GetQuestionsWithQuestionType()
        {
           return _questionDal.GetQuestionsWithQuestionType();
        }

        public void TAdd(Question t)
        {
            _questionDal.Add(t);
        }

        public void TDelete(Question t)
        {
            _questionDal.Delete(t);
        }

        public Question TGetById(int id)
        {
            return _questionDal.GetById(id);
        }

        public List<Question> TGetList()
        {
            return _questionDal.GetList();
        }

        public List<Question> TGetList(Expression<Func<Question, bool>> filter)
        {
            return _questionDal.GetList(filter);
        }

        public void TUpdate(Question t)
        {
            _questionDal.Update(t);
        }
    }
}
