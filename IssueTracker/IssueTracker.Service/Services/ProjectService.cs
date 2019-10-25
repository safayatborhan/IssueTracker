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

        public async Task Create(Project Project)
        {
            _context.Project.Add(Project);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var project = _context.Project.Where(x => x.Id == id).FirstOrDefault();
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Project Project)
        {
            _context.Project.Update(Project);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Project> GetAll()
        {
            var projects = _context.Project
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
    }
}
