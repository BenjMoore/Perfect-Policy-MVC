using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models.OptionModels
{
    public class OptionCreate
    {
        [Required]
        public string OptionText { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public int QuestionID { get; set; }
    }
}
