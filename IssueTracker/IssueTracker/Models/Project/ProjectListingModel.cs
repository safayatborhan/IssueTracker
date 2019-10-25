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
    }
}
