using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class ProjectWiseStatus
    {
        public int Id { get; set; }
        public virtual Company Company { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectContactPerson ProjectContactPerson { get; set; }
        public string Remarks { get; set; }
        public EnumRelationWithClient RelationWithClient { get; set; }
        public DateTime LastVisitDate { get; set; }
        public virtual ApplicationUser StatusBy { get; set; }
    }
}
