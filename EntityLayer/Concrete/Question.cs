using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Question
    {
        [Key]
        public int Question_ID { get; set; }
        public string QuestionLine { get; set; }
        public DateTime CreateDate { get; set; }

        public int QuestionTypeID { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<AnswerLine> AnswerLines { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }
    }
}
