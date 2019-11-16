using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class WorkListForChartViewModel
    {
        public string DateOfMonth { get; set; }
        public IEnumerable<ProjectWiseWorkList> LstProjectHour { get; set; }
    }

    public class ProjectWiseWorkList
    {
        public string ProjectName { get; set; }
        public double Hour { get; set; }
    }
}