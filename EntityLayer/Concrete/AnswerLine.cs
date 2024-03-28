using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AnswerLine
    {
        [Key]
        public int AnswerLine_ID { get; set; }
        public string Answer { get; set; }

        public int Question_ID { get; set; }
        public Question Question { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
