using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class IssueLog
    {
        public int Id { get; set; }
        public virtual Project Project { get; set; }
        public DateTime IssueDate { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Note { get; set; }
        public ApplicationUser EntryBy { get; set; }
        public ApplicationUser AssignBy { get; set; }
        public DateTime AssignDate { get; set; }
        public string AssignRemarks { get; set; }
        public virtual IEnumerable<IssueLogInvolvedPerson> IssueLogInvolvedPersons { get; set; }
        public EnumIssuePriority Priority { get; set; }
        public double TaskHour { get; set; }
        public EnumIssueType IssueType { get; set; }
        public bool IsComplete { get; set; }
    }
}
