using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models.QuestionModels
{
    public class QuestionCreate
    {
        [Required]
        public string QuestionTopic { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string QuestionImage { get; set; }
        [Required]
        public int QuizID { get; set; }

    }
}
