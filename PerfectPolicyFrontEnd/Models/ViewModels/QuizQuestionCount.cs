using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models.ViewModels
{
    public class QuizQuestionCount
    {
        [Required]
        public string QuizTitle { get; set; }
        [Required]
        public int QuestionCount { get; set; }

    }
}
