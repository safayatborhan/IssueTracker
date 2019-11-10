using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class IssueLogInvolvedPerson
    {
        public int Id { get; set; }
        public ApplicationUser InvolvedPerson { get; set; }
        public double HoursToComplete { get; set; }
        public double ExpectedHour { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string ReceiveRemarks { get; set; }
        public bool IsComplete { get; set; }

        public IssueLog IssueLog{ get; set; }
    }
}
