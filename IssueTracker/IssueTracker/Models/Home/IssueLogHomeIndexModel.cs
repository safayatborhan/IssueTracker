using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class IssueLogHomeIndexModel
    {
        public string WelcomeMessage { get; set; }
        public int DeadlineMissedCount { get; set; }
        public IEnumerable<DeadlineMissedIssue> DeadlineMissedIssues { get; set; }
        public int TodaysIssueCount { get; set; }
        public IEnumerable<TodaysIssue> TodaysIssues { get; set; }
        public int UpcomingIssueCount { get; set; }
        public IEnumerable<UpcomingIssue> UpcomingIssues { get; set; }
    }

    public class DeadlineMissedIssue
    {
        public string Text { get; set; }
    }

    public class TodaysIssue
    {
        public string Text { get; set; }
    }

    public class UpcomingIssue
    {
        public string Text { get; set; }
    }
}
