using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class EmployeeWorkDetail
    {
        public IEnumerable<EmployeeWorkDetailUsers> EmployeeWorkDetailUsers { get; set; }
        public IEnumerable<EmployeeWorkHourDetailList> EmployeeWorkHourDetailList { get; set; }
        [Display(Name = "Employee")]
        public string Id { get; set; }
    }
    public class EmployeeWorkHourDetailList
    {
        public string Project { get; set; }
        public string Company { get; set; }
        public string Work { get; set; }
        public string Date { get; set; }
        [Display(Name = "Time(Hour)")]
        public double Time { get; set; }
        public string Name { get; set; }
    }
    public class EmployeeWorkDetailUsers
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
