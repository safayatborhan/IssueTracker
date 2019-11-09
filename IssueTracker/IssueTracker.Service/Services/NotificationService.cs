using IssueTracker.Data;
using IssueTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Service.Services
{
    public class NotificationService : INotification
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Notification notification)
        {
            _context.Notification.Add(notification);
            _context.SaveChanges();
        }

        public Notification GetById(int id)
        {
            var notification = _context.Notification.Where(x => x.Id == id).FirstOrDefault();
            return notification;
        }

        public IEnumerable<Notification> GetUserNotification(string userId)
        {
            var notifications = _context.Notification.Where(x => x.UserTo == userId).ToList();
            return notifications;
        }

        public void Update(Notification notification)
        {
            _context.Notification.Update(notification);
            _context.SaveChanges();
        }
    }
}
