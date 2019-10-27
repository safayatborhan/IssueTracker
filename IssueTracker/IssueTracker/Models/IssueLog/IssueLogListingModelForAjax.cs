using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class IssueLogListingModelForAjax
    {
        public string ProjectId { get; set; }
        public string IssueDate { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Note { get; set; }
        public string Priority { get; set; }
        public string TaskHour { get; set; }
        public string IssueType { get; set; }
        public List<string> IssueLogInvolvedPersonIds { get; set; }
    }
}
