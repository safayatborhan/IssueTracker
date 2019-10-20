using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class Company : BaseClass
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public EnumStatus enumStatus { get; set; } 
    }
}
