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
    public class ProjectWiseStatusController : Controller
    {
        private readonly IProjectWiseStatus _projectWiseStatusService;
        private readonly IProject _projectService;
        private static UserManager<ApplicationUser> _userManager;


        public ProjectWiseStatusController(IProjectWiseStatus projectWiseStatusService, IProject projectService, UserManager<ApplicationUser> userManager)
        {
            _projectWiseStatusService = projectWiseStatusService;
            _projectService = projectService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var projectWiseStatus = _projectWiseStatusService.GetAll();
            var model = projectWiseStatus.Select(x => new ProjectWiseStatusListingModel
            {
                Id = x.Id,
                CompanyName = x.Company.Name,
                ProjectName = x.Project.Name,
                LastStatusDate = BuildLastStatusDate(x.Project),
                StatusBy = x.StatusBy.UserName,
                ProjectContactPersonName = x.ProjectContactPerson.Name,
                ContractEndDate = x.Project.EndOfContractDate.ToString("dd MMM yyyy"),
                Remarks = x.Remarks,
                RelationWithClientString = x.RelationWithClient.ToString(),
                LastVisitDate = x.LastVisitDate.ToString("dd MMM yyyy"),
                ProjectType = x.Project.ProjectType.ToString()
            });
            var indexModel = new ProjectWiseStatusIndexModel
            {
                ProjectWiseStatusList = model
            };
            return View(indexModel);
        }

        public IActionResult Create()
        {
            var projects = BuildProjectList();
            var companies = BuildCompanyList();
            var contactPersons = BuildContactPersonList();
            var model = new ProjectWiseStatusListingModel
            {
                Projects = projects,
                Companies = companies,
                ProjectContactPersons = contactPersons
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectWiseStatusListingModel model)
        {
            if (ModelState.IsValid)
            {
                var projectWiseStatus = BuildProjectWiseStatus(model);
                _projectWiseStatusService.Create(projectWiseStatus);
                return RedirectToAction("Index", "ProjectWiseStatus");
            }
            //var companies = _projectService.GetAllCompanies();
            //model.Companies = companies.Select(x => new CompanyListingModel
            //{
            //    Id = x.Id,
            //    Name = x.Name
            //});
            return View(model);
        }

        private ProjectWiseStatus BuildProjectWiseStatus(ProjectWiseStatusListingModel model)
        {
            var project = _projectService.GetById(model.ProjectId);
            var projectContactPerson = _projectService.GetContactPersonById(model.ProjectContactPersonId);
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var projectWiseStatus = new ProjectWiseStatus
            {
                Company = project.Company,
                Project = project,
                ProjectContactPerson = projectContactPerson,
                Remarks = model.Remarks,
                RelationWithClient = model.RelationWithClient,
                LastVisitDate = DateTime.Now,
                StatusBy = user
            };
            return projectWiseStatus;
        }

        private string BuildLastStatusDate(Project project)
        {
            var lastStatusProjectWiseStatus = _projectWiseStatusService.GetByProject(project.Id);
            string statusDate = string.Empty;
            if (lastStatusProjectWiseStatus.Any())
                statusDate = lastStatusProjectWiseStatus.OrderByDescending(x => x.LastVisitDate).FirstOrDefault().LastVisitDate.ToString("dd MMM yyyy");
            //statusDate = lastStatusProjectWiseStatus.OrderByDescending(x => x.LastVisitDate).Skip(1).FirstOrDefault().LastVisitDate.ToString("dd MMM yyyy");

            return statusDate;
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

        private IEnumerable<ContactPersonListingModel> BuildContactPersonList()
        {
            var contactPersons = _projectService.GetAllContactPerson();
            var model = contactPersons.Select(x => new ContactPersonListingModel
            {
                Id = x.Id,
                Name = x.Name
            });
            return model;
        }
    }
}