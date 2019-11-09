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
    public class ProjectController : Controller
    {
        private readonly IProject _projectService;
        private static UserManager<ApplicationUser> _userManager;

        public ProjectController(IProject projectService, UserManager<ApplicationUser> userManager)
        {
            _projectService = projectService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var projects = _projectService.GetAll();
            var model = BuildProjectIndex(projects);
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            var companies = BuildCompanyList();
            var model = new ProjectListingModel
            {
                ProjectType = null,
                Status = null,
                EndOfContractDate = null,
                Companies = companies
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectListingModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                var project = BuildProjectForCreate(model, user);
                await _projectService.Create(project);
                
                return RedirectToAction(nameof(Index));
            }
            var companies = BuildCompanyList();
            model.Companies = companies;
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectService.GetById((int)id);
            var model = BuildProjectForEdit(project);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectListingModel projectModel)
        {
            if (id != projectModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = _userManager.GetUserId(User);
                    var user = _userManager.FindByIdAsync(userId).Result;
                    var createdUser = _userManager.FindByIdAsync(projectModel.CreatedBy).Result;
                    var project = BuildProjectForEditSave(projectModel, user, createdUser);
                    await _projectService.Edit(project);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projectModel);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private ProjectListingModel BuildProjectForEdit(Project project)
        {
            var model = new ProjectListingModel
            {
                Id = project.Id,
                Code = project.Code,
                Name = project.Name,
                ProjectType = project.ProjectType,
                CompanyId = project.Company.Id,
                Status = project.Status,
                EndOfContractDate = project.EndOfContractDate,
                CreatedBy = project.CreatedBy.Id,
                CreatedDate = project.CreationDate,
                Companies = BuildCompanyList()
            };
            return model;
        }

        private Project BuildProjectForEditSave(ProjectListingModel model, ApplicationUser applicationUser, ApplicationUser createdUser)
        {
            var project = new Project
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                ProjectType = (EnumProjectType)model.ProjectType,
                Company = BuildCompany(model.CompanyId),
                Status = (EnumProjectStatus)model.Status,
                EndOfContractDate = (DateTime)model.EndOfContractDate,
                CreatedBy = createdUser,
                CreationDate = model.CreatedDate,
                ModifiedBy = applicationUser,   
                ModifiedDate = DateTime.Now
            };

            return project;
        }

        private Project BuildProjectForCreate(ProjectListingModel model, ApplicationUser applicationUser)
        {
            var project = new Project
            {
                Code = model.Code,
                Name = model.Name,
                ProjectType = (EnumProjectType)model.ProjectType,
                Company = BuildCompany(model.CompanyId),
                Status = (EnumProjectStatus)model.Status,
                EndOfContractDate = (DateTime)model.EndOfContractDate,
                CreatedBy = applicationUser,
                CreationDate = DateTime.Now
            };

            return project;
        }

        private IEnumerable<ProjectListingModel> BuildProjectIndex(IEnumerable<Project> projects)
        {
            var model = projects.Select(x => new ProjectListingModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                CompanyId = x.Company.Id,
                ProjectType = x.ProjectType,
                Status = x.Status,
                EndOfContractDate = x.EndOfContractDate,
                CompanyName = x.Company.Name,
                Companies = BuildCompanyList()
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

        private Company BuildCompany(int companyId)
        {
            var company = _projectService.GetCompanyById(companyId);
            //var model = new Company
            //{
            //    Id = company.Id,
            //    Code = company.Code,
            //    Name = company.Name,
            //    Status = company.Status,
            //    CreatedBy = company.CreatedBy,
            //    CreationDate = company.CreationDate,
            //    ModifiedBy = company.ModifiedBy,
            //    ModifiedDate = company.ModifiedDate
            //};
            return company;
        }
    }
}