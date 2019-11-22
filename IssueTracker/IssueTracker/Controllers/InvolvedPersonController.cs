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
        public IActionResult IndexForAll()
        {
            var userId = _userManager.GetUserId(User);
            var involvedPersons = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == false).OrderBy(x => x.IssueLog.IssueDate);
            var model = BuildInvolvedPersonIndex(involvedPersons);
            return View("Index", model);
        }

        [Authorize]
        [HttpGet("Index/{id}")]
        public IActionResult Index(int id)
        {
            // id = 1 for previous, 2 for today, 3 for next days
            var userId = _userManager.GetUserId(User);
            IEnumerable<IssueLogInvolvedPerson> involvedPersons = null;
            if(id == 1)
                involvedPersons = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == false && x.IssueLog.IssueDate.Date < DateTime.Now.Date).OrderBy(x => x.IssueLog.IssueDate);
            else if (id == 2)
                involvedPersons = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == false && x.IssueLog.IssueDate.Date == DateTime.Now.Date).OrderBy(x => x.IssueLog.IssueDate);
            else if (id == 3)
                involvedPersons = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == false && x.IssueLog.IssueDate.Date > DateTime.Now.Date).OrderBy(x => x.IssueLog.IssueDate);
            else
                involvedPersons = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == false).OrderBy(x => x.IssueLog.IssueDate);
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
            return RedirectToAction("IndexForAll", "InvolvedPerson");
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            IEnumerable<IssueLogInvolvedPerson> involvedPersons = null;
            var userId = _userManager.GetUserId(User);
            if(!string.IsNullOrEmpty(searchQuery))
                involvedPersons = _involvedPersonService.GetAllLogs(userId)
                    .Where(x => x.IsComplete == false && (x.IssueLog.Header.ToUpper().Contains(searchQuery.ToUpper()) || x.IssueLog.Project.Name.ToUpper().Contains(searchQuery.ToUpper()) || x.IssueLog.Project.Company.Name.ToUpper().Contains(searchQuery.ToUpper())))
                    .OrderBy(x => x.IssueLog.IssueDate);
            else
                involvedPersons = _involvedPersonService.GetAllLogs(userId)
                    .Where(x => x.IsComplete == false)
                    .OrderBy(x => x.IssueLog.IssueDate);
            var model = BuildInvolvedPersonIndex(involvedPersons);
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> View(IssueLogInvolvedPersonListingModel model)
        {
            var issuelogInvolvedPerson = _involvedPersonService.GetById(model.Id);
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var notification = new Notification();
            if (model.IsStart)
            {
                issuelogInvolvedPerson.ReceiveDate = DateTime.Now;
                issuelogInvolvedPerson.ExpectedHour = model.ExpectedHour;
                
                notification = new Notification
                {
                    UserFrom = user.Id,
                    UserFromImage = user.ProfileImageUrl,
                    UserTo = issuelogInvolvedPerson.IssueLog.EntryBy.Id,
                    Header = issuelogInvolvedPerson.IssueLog.Project.Name + "(" + issuelogInvolvedPerson.IssueLog.Project.Company.Name + ")",
                    Message = user.UserName + " has started working on " + issuelogInvolvedPerson.IssueLog.Header + ". Expected Hour is " + model.ExpectedHour,
                    IsRead = false
                };
            }                
            else
            {
                issuelogInvolvedPerson.IsComplete = true;
                issuelogInvolvedPerson.HoursToComplete = model.HoursToComplete;
                issuelogInvolvedPerson.SubmitDate = DateTime.Now;

                notification = new Notification
                {
                    UserFrom = user.Id,
                    UserFromImage = user.ProfileImageUrl,
                    UserTo = issuelogInvolvedPerson.IssueLog.EntryBy.Id,
                    Header = issuelogInvolvedPerson.IssueLog.Project.Name + "(" + issuelogInvolvedPerson.IssueLog.Project.Company.Name + ")",
                    Message = user.UserName + " has completed this task - " + issuelogInvolvedPerson.IssueLog.Header + ". Time taken : " + model.HoursToComplete + " hours",
                    IsRead = false
                };
            }                
            await _involvedPersonService.UpdateIssueLog(issuelogInvolvedPerson);
            
            _notificationService.Create(notification);
            return RedirectToAction("Index", "InvolvedPerson",new { id = 0});
        }

        private IssueLogInvolvedPersonListingModel BuildAssignedIssueModel(IssueLogInvolvedPerson issuelogInvolvedPerson)
        {            
            var p = issuelogInvolvedPerson;
            var otherInvolvedPersons = _involvedPersonService.GetAllByIssueLogId(p.IssueLog.Id).ToList().Where(x => x.InvolvedPerson.Id != p.InvolvedPerson.Id);
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
            model.OtherWorkingStatus = new List<string>();
            foreach (var involvedPerson in otherInvolvedPersons)
            {
                model.OtherWorkingStatus.Add(involvedPerson.InvolvedPerson.UserName +(!involvedPerson.IsComplete ? (involvedPerson.ReceiveDate != DateTime.MinValue ? " has started working on this task." : " hasn't started working on this task yet") : " has completed the assigned task"));
            }
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
                Title = x.IssueLog.Header,
                IsAllTeamMemberCompleted = _involvedPersonService.GetAllByIssueLogId(x.IssueLog.Id).ToList().Where(y => y.InvolvedPerson.Id != x.InvolvedPerson.Id).All(y => y.IsComplete)
            });

            return model;
        }
    }
}