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
    public class EfAnswerLineRepository : EfGenericRepository<AnswerLine>, IAnswerLineDal
    {
        public List<AnswerLine> AnswerListWithQuestion()
        {
            using (var c = new Context())
            {
                return c.AnswerLines.Include(x=>x.Question).ToList();
            }
        }
    }
}
