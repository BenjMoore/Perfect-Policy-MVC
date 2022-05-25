using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models.QuizModels
{
    public class QuizCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Creator { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        
        public int PassingPercentage { get; set; }
    }
}
