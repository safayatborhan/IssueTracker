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
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Controllers
{
    public class IssueLogController : Controller
    {
        private readonly IIssueLog _issueLogService;
        private readonly IProject _projectService;
        private static UserManager<ApplicationUser> _userManager;

        public IssueLogController(IIssueLog issueLogService,IProject projectService, UserManager<ApplicationUser> userManager)
        {
            _issueLogService = issueLogService;
            _projectService = projectService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var issueLogs = _issueLogService.GetAll();
            var model = BuildIssueLogIndex(issueLogs);
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            var projects = BuildProjectList();
            var companies = BuildCompanyList();
            var model = new IssueLogListingModel
            {
                Projects = projects,
                Companies = companies,
                IssueDate = null,
                Priority = null,
                IssueType = null,
                ApplicationUserListingModels = BuildApplicationUserList()
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IssueLogListingModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                var issueLog = BuildIssueLogForCreate(model, user);
                await _issueLogService.Create(issueLog);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult FindProject(int companyId)
        {
            var projects = _projectService.GetAll()
                .Where(x => x.Company.Id == companyId)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name
                }).ToList();
            return new JsonResult(projects);
        }

        public IActionResult FindInvolvedPerson(string issueInvolvedPersonId)
        {
            var users = _userManager.Users.Include(x => x.Designation);
            var user = users.Where(x => x.Id == issueInvolvedPersonId).FirstOrDefault();
            var issueInvolvedPerson = new
            {
                id = user.Id,
                name = user.UserName,
                emailAddress = user.Email,
                designation = user.Designation != null ? user.Designation.Name : ""
            };
            return new JsonResult(issueInvolvedPerson);
        }

        private IEnumerable<ApplicationUserListingModel> BuildApplicationUserList()
        {
            var users = _userManager.Users;
            var model = users.Select(x => new ApplicationUserListingModel
            {
                Id = x.Id,
                Name = x.UserName
            });
            return model;
        }

        private IEnumerable<ProjectListingModel> BuildProjectList()
        {
            var projects = _projectService.GetAll();
            var model = projects.Select(x => new ProjectListingModel
            {
                Id = x.Id,
                Name = x.Name,
                CompanyId = x.Company.Id
            });
            return model;
        }

        private IssueLog BuildIssueLogForCreate(IssueLogListingModel model, ApplicationUser applicationUser)
        {
            var issueLog = new IssueLog
            {
                Project = BuildProject(model.ProjectId),
                IssueDate = (DateTime)model.IssueDate,
                Header = model.Header,
                Body = model.Body,
                Note = model.Note,
                EntryBy = applicationUser,
                AssignDate = DateTime.Now,
                IssueLogInvolvedPersons = BuildIssueLogInvolvedPerson(model,applicationUser),
                Priority = (EnumIssuePriority)model.Priority,
                TaskHour = model.TaskHour,
                IssueType = (EnumIssueType)model.IssueType
            };

            return issueLog;
        }

        private IEnumerable<IssueLogInvolvedPerson> BuildIssueLogInvolvedPerson(IssueLogListingModel model, ApplicationUser applicationUser)
        {
            var involvedPersons = new List<IssueLogInvolvedPerson>();
            var involvedPerson = new IssueLogInvolvedPerson
            {
                InvolvedPerson = applicationUser
            };
            involvedPersons.Add(involvedPerson);
            return involvedPersons;
        }

        private Project BuildProject(int projectId)
        {
            var project = _projectService.GetById(projectId);
            return project;
        }

        private IEnumerable<CompanyListingModel> BuildCompanyList()
        {
            var companies = _projectService.GetAllCompanies();
            var model = companies.Select(x => new CompanyListingModel
            {
                Id = x.Id,
                Name = x.Name
            });
            return model;
        }

        private IEnumerable<IssueLogListingModel> BuildIssueLogIndex(IEnumerable<IssueLog> issueLogs)
        {
            var model = issueLogs.Select(x => new IssueLogListingModel
            {
                Id = x.Id,
                ProjectName = x.Project.Name,
                CompanyName = x.Project.Company.Name,
                IssueDate = x.IssueDate != DateTime.MinValue ? (DateTime?)x.IssueDate : null,
                Header = x.Header,
                IssueInvolvedPersonsName = String.Join(", ",x.IssueLogInvolvedPersons.Select(y => y.InvolvedPerson.UserName))
            });
            return model;
        }
    }
}