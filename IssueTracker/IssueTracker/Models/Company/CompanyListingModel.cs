using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class CompanyListingModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public EnumStatus enumStatus { get; set; }
    }
}
