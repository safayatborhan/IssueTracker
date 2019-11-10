using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class IssueLogListingModel
    {
        public int Id { get; set; }
        public ProjectListingModel Project { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Expected Date")]
        [DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Body { get; set; }
        public string Note { get; set; }
        public ApplicationUser EntryBy { get; set; }
        public string EntryById { get; set; }
        public ApplicationUser AssignBy { get; set; }
        public string AssignById { get; set; }
        public DateTime? AssignDate { get; set; }
        public string AssignRemarks { get; set; }
        [Required]
        public EnumIssuePriority? Priority { get; set; }
        [Required]
        [Display(Name = "Expected Hour")]
        public double TaskHour { get; set; }
        [Required]
        [Display(Name = "Issue Type")]
        public EnumIssueType? IssueType { get; set; }
        [Display(Name = "Involved Person")]
        public int IssueLogInvolvedPersonId { get; set; }
        [Display(Name = "Involved Persons")]
        public string IssueInvolvedPersonsName { get; set; }
        [Required]
        [Display(Name = "Select a company")]
        public int CompanyId { get; set; }
        [Required]
        [Display(Name = "Select a project")]
        public int ProjectId { get; set; }

        public IEnumerable<string> IssueLogInvolvedPersonIds { get; set; }

        public IEnumerable<IssueLogInvolvedPersonListingModel> IssueLogInvolvedPersons { get; set; }
        public IEnumerable<ProjectListingModel> Projects { get; set; }
        public IEnumerable<CompanyListingModel> Companies { get; set; } 
        public IEnumerable<ApplicationUserListingModel> ApplicationUserListingModels { get; set; }

        public string CurrentLoginUserId { get; set; }
        public bool IsAllInvolvedPersonCompleted { get; set; }
    }
}
