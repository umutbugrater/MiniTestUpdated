using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionType
    {
        [Key]
        public int QuestionTypeID { get; set; }
        public string QuestionTypeName { get; set; }

        public List<Question> Questions { get; set; }
    }
}
