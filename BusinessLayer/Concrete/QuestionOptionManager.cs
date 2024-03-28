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
    public class QuestionOptionManager : IQuestionOptionService
    {
        IQuestionOptionsDal _questionOptionDal;

        public QuestionOptionManager(IQuestionOptionsDal questionOptionDal)
        {
            _questionOptionDal = questionOptionDal;
        }

        public void TAdd(QuestionOption t)
        {
            _questionOptionDal.Add(t);
        }

        public void TDelete(QuestionOption t)
        {
            _questionOptionDal.Delete(t);
        }

        public QuestionOption TGetById(int id)
        {
            return _questionOptionDal.GetById(id);
        }

        public List<QuestionOption> TGetList()
        {
            return _questionOptionDal.GetList();
        }

        public List<QuestionOption> TGetList(Expression<Func<QuestionOption, bool>> filter)
        {
            return _questionOptionDal.GetList(filter);
        }

        public void TUpdate(QuestionOption t)
        {
            _questionOptionDal.Update(t);
        }
    }
}
