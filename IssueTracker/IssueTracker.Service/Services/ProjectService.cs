using IssueTracker.Data;
using IssueTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Service.Services
{
    public class ProjectService : IProject
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Project Project)
        {
            _context.Project.Add(Project);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _context.Project.Where(x => x.Id == id).FirstOrDefault();
            _context.Project.Remove(project);
            _context.SaveChanges();
        }

        //public async Task Edit(Project Project)
        //{
        //    _context.Project.Update(Project);
        //    await _context.SaveChangesAsync();
        //}

        public void Edit(Project Project)
        {
            var projectSaved = GetById(Project.Id);
            var supportMembers = projectSaved.SupportMembers;
            var projectContactPersons = projectSaved.ProjectContacPersons;
            if (supportMembers.Any())
            {
                foreach (var supportMember in supportMembers)
                {
                    _context.Entry(supportMember).State = EntityState.Deleted;
                }
            }
            if (projectContactPersons.Any())
            {
                foreach (var projectContactPerson in projectContactPersons)
                {
                    _context.Entry(projectContactPerson).State = EntityState.Deleted;
                }
            }
            projectSaved.Id = projectSaved.Id;
            projectSaved.ProjectType = Project.ProjectType;
            projectSaved.Code = Project.Code;
            projectSaved.Name = Project.Name;
            projectSaved.Company = Project.Company;
            projectSaved.Status = Project.Status;
            projectSaved.EndOfContractDate = Project.EndOfContractDate;
            projectSaved.SupportMembers = Project.SupportMembers;
            projectSaved.ProjectContacPersons = Project.ProjectContacPersons;

            _context.SaveChanges();
        }

        public IEnumerable<Project> GetAll()
        {
            var projects = _context.Project
                .Include(x => x.SupportMembers)
                    .ThenInclude(y => y.ApplicationUser)
                .Include(x => x.ProjectContacPersons)
                .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .Include(x => x.Company)
                    .ThenInclude(y => y.CreatedBy)
                    .Include(y => y.ModifiedBy)
                .ToList();
            return projects;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var companies = _context.Company.ToList();
            return companies;
        }

        public Project GetById(int id)
        {
            var project = _context.Project.Where(x => x.Id == id)
                .Include(x => x.SupportMembers)
                    .ThenInclude(y => y.ApplicationUser)
                        .ThenInclude(z => z.Designation)
                .Include(x => x.ProjectContacPersons)
                .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .Include(x => x.Company)
                    .ThenInclude(y => y.CreatedBy)
                    .FirstOrDefault();
            return project;
        }

        public Company GetCompanyById(int id)
        {
            var company = _context.Company.Where(x => x.Id == id).FirstOrDefault();
            return company;
        }

        public ProjectContactPerson GetContactPersonById(int id)
        {
            var contactPersons = _context.ProjectContactPerson.Where(x => x.Id == id).FirstOrDefault();
            return contactPersons;
        }

        public IEnumerable<ProjectContactPerson> GetAllContactPerson()
        {
            var contactPersons = _context.ProjectContactPerson.ToList();
            return contactPersons;
        }
    }
}
