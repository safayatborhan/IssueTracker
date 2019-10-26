using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class ApplicationUserListingModel
    {
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string Designation { get; set; }
    }
}
