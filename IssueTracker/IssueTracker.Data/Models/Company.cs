using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class Company : BaseClass
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]        
        public EnumStatus Status { get; set; } 
    }
}
