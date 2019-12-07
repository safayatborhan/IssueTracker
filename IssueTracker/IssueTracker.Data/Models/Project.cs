using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class Project : BaseClass
    {
        public int Id { get; set; }
        public EnumProjectType ProjectType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Company Company { get; set; }
        public EnumProjectStatus Status { get; set; }
        public DateTime EndOfContractDate { get; set; }

        public virtual IEnumerable<ProjectSupportPerson> SupportMembers { get; set; }
        public virtual IEnumerable<ProjectContactPerson> ProjectContacPersons { get; set; }
    }
}
