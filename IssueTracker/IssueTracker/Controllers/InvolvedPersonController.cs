using System;
using System.Collections.Generic;
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

        public InvolvedPersonController(IInvolvedPerson involvedPersonService, UserManager<ApplicationUser> userManager)
        {
            _involvedPersonService = involvedPersonService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var involvedPersons = _involvedPersonService.GetAllLogs(userId);
            var model = BuildInvolvedPersonIndex(involvedPersons);
            return View(model);
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
                IssueType = x.IssueLog.IssueType.ToString()
            });
            return model;
        }
    }
}