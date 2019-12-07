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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                Companies = companies,
                SupportMembers = BuildApplicationUserList()
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Create([FromBody]ProjectListingModelForAjax projectListingModel)
        {
            if (ModelState.IsValid)
            {
                List<string> supprotPersonIds = new List<string>();
                if (!string.IsNullOrEmpty(projectListingModel.ProjectSupportPersonIds))
                    supprotPersonIds = projectListingModel.ProjectSupportPersonIds.Split(',').ToList();
                var userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                var supportPersons = new List<ApplicationUser>();
                if (supprotPersonIds.Count() > 0)
                {
                    supportPersons = _userManager.Users.Where(x => supprotPersonIds.Contains(x.Id)).ToList();
                }

                ContactPersonListingModelVM ContactPersons = JsonConvert.DeserializeObject<ContactPersonListingModelVM>(projectListingModel.ContactPersonsString);

                var project = BuildProjectForCreate(projectListingModel, user, supportPersons, ContactPersons);
                _projectService.Create(project);

                return Json(new
                {
                    redirectTo = Url.Action("Index", "Project")
                });
            }
            return Json(new
            {
                redirectTo = Url.Action("Index", "Project")
            });
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
        
        [HttpPost]
        public JsonResult Edit([FromBody]ProjectListingModelForAjax projectListingModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<string> supprotPersonIds = new List<string>();
                    if (!string.IsNullOrEmpty(projectListingModel.ProjectSupportPersonIds))
                        supprotPersonIds = projectListingModel.ProjectSupportPersonIds.Split(',').ToList();
                    var userId = _userManager.GetUserId(User);
                    var user = _userManager.FindByIdAsync(userId).Result;
                    var supportPersons = new List<ApplicationUser>();
                    if (supprotPersonIds.Count() > 0)
                    {
                        supportPersons = _userManager.Users.Where(x => supprotPersonIds.Contains(x.Id)).ToList();
                    }

                    ContactPersonListingModelVM ContactPersons = JsonConvert.DeserializeObject<ContactPersonListingModelVM>(projectListingModel.ContactPersonsString);

                    var createdUser = _userManager.FindByIdAsync(projectListingModel.CreatedBy).Result;
                    var project = BuildProjectForEditSave(projectListingModel, user, createdUser, supportPersons, ContactPersons);
                    _projectService.Edit(project);

                }
                catch (DbUpdateConcurrencyException)
                {
                    //return NotFound();
                }
                return Json(new
                {
                    redirectTo = Url.Action("Index", "Project")
                });
            }
            return Json(new
            {
                redirectTo = Url.Action("Index", "Project")
            });
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
                Companies = BuildCompanyList(),
                ProjectContactPersons = BuildCotactPersonForEdit(project.ProjectContacPersons),
                SupportMembers = BuildApplicationUserList(),
                SupportPersonListingModel = BuildSupportPersonsForEdit(project.SupportMembers)
            };
            return model;
        }

        private IEnumerable<ContactPersonListingModel> BuildCotactPersonForEdit(IEnumerable<ProjectContactPerson> projectContacPersons)
        {
            var model = new List<ContactPersonListingModel>();
            foreach (var cp in projectContacPersons)
            {
                var person = new ContactPersonListingModel
                {
                    Id = cp.Id,
                    Name = cp.Name,
                    Designation = cp.Designation,
                    Mobile = cp.Mobile,
                    Email = cp.Email
                };
                model.Add(person);
            }

            return model;
        }

        private IEnumerable<SupprotPersonListingModel> BuildSupportPersonsForEdit(IEnumerable<ProjectSupportPerson> projectSupportPersons)
        {
            var model = new List<SupprotPersonListingModel>();
            foreach (var sp in projectSupportPersons)
            {
                var person = new SupprotPersonListingModel
                {
                    Id = sp.ApplicationUser.Id,
                    UserId = sp.ApplicationUser.Id,
                    UserName = sp.ApplicationUser.UserName,
                    EmailAddress = sp.ApplicationUser.Email,
                    Designation = sp.ApplicationUser.DesignationName
                };
                model.Add(person);
            }

            return model;
        }

        private Project BuildProjectForEditSave(ProjectListingModelForAjax model, ApplicationUser applicationUser, ApplicationUser createdUser, List<ApplicationUser> supportPersons, ContactPersonListingModelVM ContactPersons)
        {
            var project = new Project
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                ProjectType = (EnumProjectType)int.Parse(model.ProjectType),
                Company = BuildCompany(int.Parse(model.CompanyId)),
                Status = (EnumProjectStatus)int.Parse(model.Status),
                EndOfContractDate = (DateTime)DateTime.Parse(model.EndOfContractDate),
                CreatedBy = createdUser,
                CreationDate = DateTime.Parse(model.CreatedDate),
                ModifiedBy = applicationUser,   
                ModifiedDate = DateTime.Now,
                SupportMembers = BuildProjectSupportPerson(supportPersons),
                ProjectContacPersons = BuildProjectContactPerson(ContactPersons.ContactPersonsString)
            };

            return project;
        }

        private Project BuildProjectForCreate(ProjectListingModelForAjax model, ApplicationUser applicationUser, List<ApplicationUser> supportPersons, ContactPersonListingModelVM ContactPersons)
        {
            var project = new Project
            {
                Code = model.Code,
                Name = model.Name,
                ProjectType = (EnumProjectType)int.Parse(model.ProjectType),
                Company = BuildCompany(int.Parse(model.CompanyId)),
                Status = (EnumProjectStatus)int.Parse(model.Status),
                EndOfContractDate = (DateTime)DateTime.Parse(model.EndOfContractDate),
                CreatedBy = applicationUser,
                CreationDate = DateTime.Now,
                SupportMembers = BuildProjectSupportPerson(supportPersons),
                ProjectContacPersons = BuildProjectContactPerson(ContactPersons.ContactPersonsString)
            };

            return project;
        }

        private IEnumerable<ProjectContactPerson> BuildProjectContactPerson(IEnumerable<ContactPersonListingModel> contactPersonsModel)
        {
            var contactPersons = new List<ProjectContactPerson>();
            foreach (var cp in contactPersonsModel)
            {
                var contactPerson = new ProjectContactPerson();
                contactPerson.Name = cp.Name;
                contactPerson.Designation = cp.Designation;
                contactPerson.Email = cp.Email;
                contactPerson.Mobile = cp.Mobile;
                contactPersons.Add(contactPerson);
            }
            return contactPersons;
        }

        private IEnumerable<ProjectSupportPerson> BuildProjectSupportPerson(IEnumerable<ApplicationUser> supportPersonsModel)
        {
            var supportPersons = new List<ProjectSupportPerson>();
            foreach (var ip in supportPersonsModel)
            {
                var supportPerson = new ProjectSupportPerson();
                supportPerson.ApplicationUser = new ApplicationUser();
                supportPerson.ApplicationUser.Id = ip.Id;
                supportPersons.Add(supportPerson);
            }
            return supportPersons;
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

        private IEnumerable<ApplicationUserListingModel> BuildApplicationUserList()
        {
            var currentUserId = _userManager.GetUserId(User);

            var users = _userManager.Users.ToList();
            var model = users.Select(x => new ApplicationUserListingModel
            {
                Id = x.Id,
                Name = x.UserName
            });
            return model;
        }
    }
}