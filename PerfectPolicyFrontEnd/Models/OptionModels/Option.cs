using PerfectPolicyFrontEnd.Models.QuestionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models.OptionModels
{
    public class Option
    {
        public int OptionID { get; set; }
        public string OptionText { get; set; }
        public string OptionOrderByLetter { get; set; }
        public string OptionOrderByNumber { get; set; }
        public string Answer { get; set; }

        public int QuestionID { get; set; }

        public Question question { get; set; }
        
    }
}
