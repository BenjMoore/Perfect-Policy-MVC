using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Models
{
    public class Company
    {
        [Required]
        public string CompanyName { get; set; }        
    }
}
