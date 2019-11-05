using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class IssueLogInvolvedPersonListingModel
    {
        public int Id { get; set; }
        public ApplicationUser InvolvedPerson { get; set; }
        public string InvolvedPersonId { get; set; }
        public double HoursToComplete { get; set; }
        public double ExpectedHour { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string ReceiveRemarks { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Designation { get; set; }

        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public string RaisedByName { get; set; }
        public string OtherInvolvedPersons { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public string IssueType { get; set; }

        public string Title { get; set; }
        public string Detail { get; set; }
        public string Priority { get; set; }

        public bool IsStart { get; set; }
    }
}
