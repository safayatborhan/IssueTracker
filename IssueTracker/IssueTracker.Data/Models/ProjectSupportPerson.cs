using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class ProjectSupportPerson
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Project Project { get; set; }
    }
}
