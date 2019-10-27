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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]IssueLogListingModelForAjax issueLogListingModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                var involvedPersons = new List<ApplicationUser>();
                if(issueLogListingModel.IssueLogInvolvedPersonIds.Count() > 0)
                    involvedPersons = _userManager.Users.Where(x => issueLogListingModel.IssueLogInvolvedPersonIds.Contains(x.Id)).ToList();
                involvedPersons.Add(user);
                var issueLog = BuildIssueLogForCreate(issueLogListingModel, user, involvedPersons);
                await _issueLogService.Create(issueLog);

                return RedirectToAction(nameof(Index));
            }
            return View(issueLogListingModel);
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

        private IssueLog BuildIssueLogForCreate(IssueLogListingModelForAjax model, ApplicationUser applicationUser, IEnumerable<ApplicationUser> involvedPersons)
        {
            var issueLog = new IssueLog
            {
                Project = BuildProject(int.Parse(model.ProjectId)),
                IssueDate = DateTime.Parse(model.IssueDate),
                Header = model.Header,
                Body = model.Body,
                Note = model.Note,
                EntryBy = applicationUser,
                AssignDate = DateTime.Now,
                IssueLogInvolvedPersons = BuildIssueLogInvolvedPerson(involvedPersons),
                Priority = (EnumIssuePriority)int.Parse(model.Priority),
                TaskHour = double.Parse(model.TaskHour),
                IssueType = (EnumIssueType)int.Parse(model.IssueType)
            };

            return issueLog;
        }

        private IEnumerable<IssueLogInvolvedPerson> BuildIssueLogInvolvedPerson(IEnumerable<ApplicationUser> involvedPersonsModel)
        {
            var involvedPersons = new List<IssueLogInvolvedPerson>();
            foreach(var ip in involvedPersonsModel)
            {
                var involvedPerson = new IssueLogInvolvedPerson();
                involvedPerson.InvolvedPerson = ip;
                involvedPersons.Add(involvedPerson);
            }            
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