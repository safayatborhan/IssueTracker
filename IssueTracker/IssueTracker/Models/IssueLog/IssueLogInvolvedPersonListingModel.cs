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
        public DateTime ReceiveDate { get; set; }
        public string ReceiveRemarks { get; set; }
    }
}
