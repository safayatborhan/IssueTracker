using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data
{
    public interface INotification
    {
        IEnumerable<Notification> GetUserNotification(string userId);
        void Create(Notification notification);
        Notification GetById(int id);
        void Update(Notification notification);
    }
}
