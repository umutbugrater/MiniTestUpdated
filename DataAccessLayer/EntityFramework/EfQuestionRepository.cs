using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfQuestionRepository : EfGenericRepository<Question>, IQuestionDal
    {
        public List<Question> GetQuestionsWithQuestionType()
        {
            using (var c = new Context())
            {
                return c.Questions.Include(x=>x.QuestionType).ToList();
            }
        }
    }
}
