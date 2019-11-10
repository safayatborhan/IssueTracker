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
    public class WorkDetailController : Controller
    {
        private readonly IIssueLog _issueLogService;
        private readonly IProject _projectService;
        private readonly IInvolvedPerson _involvedPersonService;
        private static UserManager<ApplicationUser> _userManager;

        public WorkDetailController(IIssueLog issueLogService, IProject projectService, IInvolvedPerson involvedPersonService, UserManager<ApplicationUser> userManager)
        {
            _issueLogService = issueLogService;
            _projectService = projectService;
            _involvedPersonService = involvedPersonService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult EmployeeWorkDetail()
        {
            var model = BuildEmloyeeWorkDetailModel();
            return View(model);
        }

        private EmployeeWorkDetail BuildEmloyeeWorkDetailModel()
        {
            var users = _userManager.Users;
            IEnumerable<EmployeeWorkDetailUsers> employeeWorkDetailUsers = users.Select(x => new EmployeeWorkDetailUsers
            {
                Id = x.Id,
                Name = x.UserName
            });
            var employeeWorkHourDetailList = _involvedPersonService.GetAll().Where(y => y.IsComplete)
                .OrderByDescending(x => x.IssueLog.IssueDate).Select(x => new EmployeeWorkHourDetailList
                {
                    Project = x.IssueLog.Project.Name,
                    Company = x.IssueLog.Project.Company.Name,
                    Work = x.IssueLog.Header,
                    Date = x.IssueLog.IssueDate.ToString("dd MMM yyyy"),
                    Time = x.HoursToComplete,
                    Name = x.InvolvedPerson.UserName
                });

            EmployeeWorkDetail model = new EmployeeWorkDetail();
            model.EmployeeWorkDetailUsers = employeeWorkDetailUsers;
            model.EmployeeWorkHourDetailList = employeeWorkHourDetailList;
            return model;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}