using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class NotificationListingModel
    {        
        public int NotificationCount { get; set; }
        public IEnumerable<NotificationBody> Notifications { get; set; }
    }
    public class NotificationBody
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Messages { get; set; }
        public string ImageUrl { get; set; }
    }
}
