using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class ProjectWiseStatusListingModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }        
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        [Display(Name = "Project")]
        public string ProjectName { get; set; }
        [Display(Name = "Contact person")]
        [Required]
        public int ProjectContactPersonId { get; set; }
        [Display(Name = "Contact Person")]
        public string ProjectContactPersonName { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Relation with client")]
        [Required]
        public EnumRelationWithClient RelationWithClient { get; set; }
        public string RelationWithClientString { get; set; }
        public string LastVisitDate { get; set; }
        public string LastStatusDate { get; set; }
        public string StatusBy { get; set; }
        public string ContractEndDate { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectType { get; set; }

        public IEnumerable<ProjectListingModel> Projects { get; set; }
        public IEnumerable<CompanyListingModel> Companies { get; set; }
        public IEnumerable<ContactPersonListingModel> ProjectContactPersons { get; set; }
    }

    public class ProjectWiseStatusIndexModel
    {
        public IEnumerable<ProjectWiseStatusListingModel> ProjectWiseStatusList { get; set; }
    }
}
