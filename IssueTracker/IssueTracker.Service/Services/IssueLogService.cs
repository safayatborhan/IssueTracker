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

        public async void Delete(int id)
        {
            var issueLog = _context.IssueLog.Where(x => x.Id == id).FirstOrDefault();
            _context.IssueLog.Remove(issueLog);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(IssueLog issueLog)
        {
            _context.IssueLog.Update(issueLog);
            await _context.SaveChangesAsync();
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
                .Include(x => x.EntryBy)
                .Include(x => x.AssignBy)
                    .FirstOrDefault();
            return issueLog;
        }

        public async void RemoveInvolvedPerson(int issueLogId, int involvedPersonId)
        {
            var issueLog = GetById(issueLogId);
            var involvedPerson = issueLog.IssueLogInvolvedPersons.Where(x => x.Id == involvedPersonId).FirstOrDefault();
            _context.IssueLogInvolvedPerson.Remove(involvedPerson);
            await _context.SaveChangesAsync();
        }
    }
}
