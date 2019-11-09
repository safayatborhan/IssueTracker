using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueTracker.Data;
using IssueTracker.Data.Models;
using IssueTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class NotificationViewComponent : ViewComponent
    {
        private static UserManager<ApplicationUser> _userManager;
        private readonly INotification _notificationService;

        public NotificationViewComponent(INotification notificationService, UserManager<ApplicationUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userManager.GetUserId(this.HttpContext.User);
            var notificaitons = _notificationService.GetUserNotification(userId);
            var model = new NotificationListingModel
            {
                NotificationCount = notificaitons.Where(x => x.IsRead == false).ToList().Count(),
                Notifications = notificaitons.Where(x => x.IsRead == false).ToList().Select(x => new NotificationBody
                {
                    Id = x.Id,
                    Header = x.Header,
                    ImageUrl = x.UserFromImage,
                    Messages = x.Message
                })
            };
            return View(model);
        }
    }
}