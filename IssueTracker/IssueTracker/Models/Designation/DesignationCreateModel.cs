using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class DesignationCreateModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
