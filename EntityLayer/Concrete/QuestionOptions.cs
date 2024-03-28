using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionOption
    {
        [Key]
        public int QuestionOptionID { get; set; }
        public string OptionDescription { get; set; }


        public int Question_ID { get; set; }
        public Question Question { get; set; }
    }
}
