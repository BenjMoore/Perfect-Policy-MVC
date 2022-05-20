using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PerfectPolicyFrontEnd.Models.QuestionModels;

namespace PerfectPolicyFrontEnd.Models.QuizModels
{
    public class Quiz
    {
        
        public int QuizID { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public int PassingPercentage { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
