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
    public class QuestionTypeManager : IQuestionTypeService
    {
        IQuestionTypeDal _questionTypeDal;

        public QuestionTypeManager(IQuestionTypeDal questionTypeDal)
        {
            _questionTypeDal = questionTypeDal;
        }

        public void TAdd(QuestionType t)
        {
            _questionTypeDal.Add(t);
        }

        public void TDelete(QuestionType t)
        {
            _questionTypeDal.Delete(t);
        }

        public QuestionType TGetById(int id)
        {
            return _questionTypeDal.GetById(id);
        }

        public List<QuestionType> TGetList()
        {
            return _questionTypeDal.GetList();
        }

        public List<QuestionType> TGetList(Expression<Func<QuestionType, bool>> filter)
        {
            return _questionTypeDal.GetList(filter);
        }

        public void TUpdate(QuestionType t)
        {
            _questionTypeDal.Update(t);
        }
    }
}
