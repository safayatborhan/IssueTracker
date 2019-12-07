using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class ProjectListingModel
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Select a company")]
        public int CompanyId { get; set; }
        [Required]
        [Display(Name = "Project Type")]
        public EnumProjectType? ProjectType { get; set; }
        [Required]
        public EnumProjectStatus? Status { get; set; }
        [Required]
        [Display(Name = "End of contract date")]
        [DataType(DataType.Date)]
        public DateTime? EndOfContractDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CompanyName { get; set; }


        public ApplicationUser ApplicationUser { get; set; }    
        public Company Company { get; set; }
        public IEnumerable<CompanyListingModel> Companies { get; set; }

        [Display(Name = "Support Person")]
        public int SupportPersonId { get; set; }
        public IEnumerable<ApplicationUserListingModel> SupportMembers { get; set; }
        public IEnumerable<ContactPersonListingModel> ProjectContactPersons { get; set; }

        public IEnumerable<string> ProjectSupportPersonIds { get; set; }

        public IEnumerable<SupprotPersonListingModel> SupportPersonListingModel { get; set; }
    }
    public class ContactPersonListingModelVM
    {
        public IEnumerable<ContactPersonListingModel> ContactPersonsString { get; set; }


    }
    public class ContactPersonListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }    

    public class SupprotPersonListingModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Designation { get; set; }
    }

    public class ProjectListingModelForAjax
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string ProjectType { get; set; }
        public string Status { get; set; }
        public string EndOfContractDate { get; set; }
        public string ProjectSupportPersonIds { get; set; }       

        public string ContactPersonsString { get; set; }
        public List<ContactPersonListingModel> ContactPersons { get; set; }     
        
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }

    }
}
