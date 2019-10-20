using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class BaseClass
    {
        public ApplicationUser CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
