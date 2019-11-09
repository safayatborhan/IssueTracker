using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserFrom { get; set; }
        public string UserFromImage { get; set; }
        public string UserTo { get; set; }
        public string Message { get; set; }
        public string Header { get; set; }
        public bool IsRead { get; set; }
    }
}
