using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IssueTracker.Data;
using IssueTracker.Data.Models;
using IssueTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class InvolvedPersonController : Controller
    {
        private static UserManager<ApplicationUser> _userManager;
        private readonly IInvolvedPerson _involvedPersonService;
        private readonly INotification _notificationService;

        public InvolvedPersonController(IInvolvedPerson involvedPersonService, UserManager<ApplicationUser> userManager, INotification notificationService)
        {
            _involvedPersonService = involvedPersonService;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var involvedPersons = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == false).OrderBy(x => x.IssueLog.IssueDate);
            var model = BuildInvolvedPersonIndex(involvedPersons);
            return View(model);
        }

        public IActionResult View(int id)
        {
            //int id = 85;
            var issuelogInvolvedPerson = _involvedPersonService.GetById(id);
            var model = BuildAssignedIssueModel(issuelogInvolvedPerson);
            return PartialView("_InvolvedPersonModalPartial", model);
        }

        public IActionResult NotificationHit(int id)
        {
            var notification = _notificationService.GetById(id);
            notification.IsRead = true;
            _notificationService.Update(notification);
            return RedirectToAction("Index", "InvolvedPerson");
        }

        [HttpPost]
        public async Task<IActionResult> View(IssueLogInvolvedPersonListingModel model)
        {
            var issuelogInvolvedPerson = _involvedPersonService.GetById(model.Id);
            if (model.IsStart)
                issuelogInvolvedPerson.ReceiveDate = DateTime.Now;
            else
            {
                issuelogInvolvedPerson.IsComplete = true;
                issuelogInvolvedPerson.HoursToComplete = model.HoursToComplete;
            }                
            await _involvedPersonService.UpdateIssueLog(issuelogInvolvedPerson);
            return RedirectToAction("Index", "InvolvedPerson");
        }

        private IssueLogInvolvedPersonListingModel BuildAssignedIssueModel(IssueLogInvolvedPerson issuelogInvolvedPerson)
        {
            var p = issuelogInvolvedPerson;
            var model = new IssueLogInvolvedPersonListingModel
            {
                Id = p.Id,
                CompanyName = p.IssueLog.Project.Company.Name,
                ProjectName = p.IssueLog.Project.Name,
                ExpectedDate = p.IssueLog.IssueDate,
                Title = p.IssueLog.Header,
                Detail = p.IssueLog.Body,
                Note = p.IssueLog.Note,
                Priority = p.IssueLog.Priority.ToString(),
                IssueType = p.IssueLog.IssueType.ToString(),
                ReceiveDate = p.ReceiveDate != DateTime.MinValue ? (DateTime?)p.ReceiveDate : null,
                IsStart = p.ReceiveDate != DateTime.MinValue ? false : true
            };
            return model;
        }

        private IEnumerable<IssueLogInvolvedPersonListingModel> BuildInvolvedPersonIndex(IEnumerable<IssueLogInvolvedPerson> involvedPersons)
        {
            var model = involvedPersons.Select(x => new IssueLogInvolvedPersonListingModel
            {
                Id = x.Id,
                ProjectName = x.IssueLog.Project.Name,
                CompanyName = x.IssueLog.Project.Company.Name,
                RaisedByName = x.IssueLog.EntryBy.UserName,
                ExpectedDate = x.IssueLog.IssueDate != DateTime.MinValue ? (DateTime?)x.IssueLog.IssueDate : null,
                ReceiveDate = x.ReceiveDate != DateTime.MinValue ? (DateTime?)x.ReceiveDate : null,
                IssueType = x.IssueLog.IssueType.ToString(),
                RaisedByImageUrl = x.IssueLog.EntryBy.ProfileImageUrl,
                Title = x.IssueLog.Header
            });
            return model;
        }
    }
}