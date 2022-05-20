using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models.QuizModels
{
    public class QuizCreate
    {
        
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; }
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PassingPercentage { get; set; }
    }
}
