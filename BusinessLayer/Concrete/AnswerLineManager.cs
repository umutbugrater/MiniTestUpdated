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
    public class AnswerLineManager : IAnswerLineService
    {
        IAnswerLineDal _answerLineDal;

        public AnswerLineManager(IAnswerLineDal answerLineDal)
        {
            _answerLineDal = answerLineDal;
        }

        public void TAdd(AnswerLine t)
        {
            _answerLineDal.Add(t);
        }

        public List<AnswerLine> TAnswerListWithQuestion()
        {
           return _answerLineDal.AnswerListWithQuestion();
        }

        public void TDelete(AnswerLine t)
        {
            _answerLineDal.Delete(t);
        }

        public AnswerLine TGetById(int id)
        {
            return _answerLineDal.GetById(id);
        }

        public List<AnswerLine> TGetList()
        {
            return _answerLineDal.GetList();
        }

        public List<AnswerLine> TGetList(Expression<Func<AnswerLine, bool>> filter)
        {
           return _answerLineDal.GetList(filter);
        }

        public void TUpdate(AnswerLine t)
        {
            _answerLineDal.Update(t);
        }
    }
}
