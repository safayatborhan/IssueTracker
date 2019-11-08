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
    public class IssueLogService : IIssueLog
    {
        private readonly ApplicationDbContext _context;

        public IssueLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddInvolvedPersons(IEnumerable<IssueLogInvolvedPerson> issueLogInvolvedPersons)
        {
            throw new NotImplementedException();
        }

        public void Create(IssueLog issueLog)
        {
            _context.IssueLog.Add(issueLog);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var issueLog = GetById(id);
            _context.IssueLog.Remove(issueLog);
            _context.IssueLogInvolvedPerson.RemoveRange(issueLog.IssueLogInvolvedPersons);
            _context.SaveChanges();
        }

        public void Edit(IssueLog issueLog)
        {
            var issueLogSaved = GetById(issueLog.Id);

            var issueLogInvolvedPersons = issueLogSaved.IssueLogInvolvedPersons;
            if (issueLogInvolvedPersons.Any())
            {
                foreach (var issueLogInvolvedPerson in issueLogInvolvedPersons)
                {
                    _context.Entry(issueLogInvolvedPerson).State = EntityState.Deleted;
                }
            }
            //_context.IssueLogInvolvedPerson.RemoveRange(issueLogSaved.IssueLogInvolvedPersons);
            issueLogSaved.Id = issueLogSaved.Id;
            issueLogSaved.Project = issueLog.Project;
            issueLogSaved.IssueDate = issueLog.IssueDate;
            issueLogSaved.Header = issueLog.Header;
            issueLogSaved.Body = issueLog.Body;
            issueLogSaved.Note = issueLog.Note;
            issueLogSaved.EntryBy = issueLog.EntryBy;
            issueLogSaved.AssignBy = issueLog.AssignBy;
            issueLogSaved.AssignDate = issueLog.AssignDate;
            issueLogSaved.AssignRemarks = issueLog.AssignRemarks;
            issueLogSaved.IssueLogInvolvedPersons = issueLog.IssueLogInvolvedPersons;
            issueLogSaved.Priority = issueLog.Priority;
            issueLogSaved.TaskHour = issueLog.TaskHour;
            issueLogSaved.IssueType = issueLog.IssueType;            

            //_context.IssueLog.Update(issueLogSaved);

            _context.SaveChanges();
        }

        public IEnumerable<IssueLog> GetAll()
        {
            var issueLogs = _context.IssueLog
                .Include(x => x.Project)
                    .ThenInclude(y => y.Company)
               .Include(x => x.IssueLogInvolvedPersons)
                    .ThenInclude(y => y.InvolvedPerson)
                .Include(x => x.EntryBy)
                .Include(x => x.AssignBy)
                .ToList();
            return issueLogs;
        }

        public IssueLog GetById(int id)
        {
            var issueLog = _context.IssueLog.Where(x => x.Id == id)
               .Include(x => x.Project)
                    .ThenInclude(y => y.Company)
               .Include(x => x.IssueLogInvolvedPersons)
                    .ThenInclude(y => y.InvolvedPerson)
                        .ThenInclude(z => z.Designation)
                .Include(x => x.EntryBy)
                .Include(x => x.AssignBy)
                    .FirstOrDefault();
            return issueLog;
        }
    }
}
