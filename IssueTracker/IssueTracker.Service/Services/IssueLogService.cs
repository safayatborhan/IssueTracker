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

        public async Task Create(IssueLog issueLog)
        {
            _context.IssueLog.Add(issueLog);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var issueLog = GetById(id);
            _context.IssueLog.Remove(issueLog);
            _context.SaveChanges();
        }

        public void Edit(IssueLog issueLog)
        {
            var issueLogToDeleteInvolvedPerson = GetById(issueLog.Id);
            _context.IssueLogInvolvedPerson.RemoveRange(issueLogToDeleteInvolvedPerson.IssueLogInvolvedPersons);
            _context.IssueLog.Update(issueLog);

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
            var issueLog = _context.IssueLog.AsNoTracking().Where(x => x.Id == id)
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
