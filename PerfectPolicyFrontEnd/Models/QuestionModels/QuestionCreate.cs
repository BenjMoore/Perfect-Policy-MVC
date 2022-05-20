using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models.QuestionModels
{
    public class QuestionCreate
    {
        public string QuestionTopic { get; set; }
        public string QuestionText { get; set; }
        public string QuestionImage { get; set; }
        public int QuizID { get; set; }

    }
}
