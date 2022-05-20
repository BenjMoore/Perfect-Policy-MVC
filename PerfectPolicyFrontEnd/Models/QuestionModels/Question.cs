using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PerfectPolicyFrontEnd.Models.QuizModels;

namespace PerfectPolicyFrontEnd.Models.QuestionModels
{
    public class Question
    {
        public int QuestionID { get; set; }
        [Display(Name = "Question Topic")]
        public string QuestionTopic { get; set; }
        
        [Display(Name = "Question Text")]
        public string QuestionText { get; set; }
        [Display(Name = "Image Name")]
        public string QuestionImage { get; set; }
        

        public int QuizID { get; set; }

        public Quiz quiz { get; set; }
        //public ICollection<Option> Options { get; set; }
    }
}
