using IssueTracker.Data;
using IssueTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IssueTracker.Service.Services
{
    public class ProjectWiseStatusService : IProjectWiseStatus
    {
        private readonly ApplicationDbContext _context;
        public ProjectWiseStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(ProjectWiseStatus ProjectWiseStatus)
        {
            _context.ProjectWiseStatus.Add(ProjectWiseStatus);
            _context.SaveChanges();
        }

        public IEnumerable<ProjectWiseStatus> GetAll()
        {
            var projectWiseStatus = _context.ProjectWiseStatus
                .Include(x => x.Company)
                .Include(x => x.Project)
                .Include(x => x.ProjectContactPerson)
                .Include(x => x.StatusBy)
                //.GroupBy(x => x.Project).Select(x => x.OrderByDescending(y => y.Id))
                .ToList();
            return projectWiseStatus;
        }

        public IEnumerable<ProjectWiseStatus> GetByProject(int ProjectId)
        {
            var projectWiseStatus = _context.ProjectWiseStatus.Where(x => x.Project.Id == ProjectId)
                .Include(x => x.Company)
                .Include(x => x.Project)
                .Include(x => x.ProjectContactPerson)
                .Include(x => x.StatusBy)
                .ToList();
            return projectWiseStatus;
        }
    }
}
