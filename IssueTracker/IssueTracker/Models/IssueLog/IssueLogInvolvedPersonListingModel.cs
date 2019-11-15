using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Raised By Name")]
        public string RaisedByName { get; set; }
        public string OtherInvolvedPersons { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expected Date")]
        public DateTime? ExpectedDate { get; set; }
        [Display(Name = "Issue Type")]
        public string IssueType { get; set; }

        public string Title { get; set; }
        public string Detail { get; set; }
        public string Priority { get; set; }

        public bool IsStart { get; set; }
        public string RaisedByImageUrl { get; set; }
        public string Note { get; set; }

        public List<string> OtherWorkingStatus { get; set; }
    }
}
