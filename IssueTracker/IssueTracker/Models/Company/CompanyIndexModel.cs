using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class CompanyIndexModel
    {
        IEnumerable<CompanyListingModel> Companies { get; set; }
    }
}
