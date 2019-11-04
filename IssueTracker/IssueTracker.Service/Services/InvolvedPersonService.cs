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
    public class InvolvedPersonService : IInvolvedPerson
    {
        private readonly ApplicationDbContext _context;
        public InvolvedPersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IssueLogInvolvedPerson> GetAllLogs(string userId)
        {
            var issueLogInvolvedPersons = _context.IssueLogInvolvedPerson
                .Include(x => x.InvolvedPerson)
                    .ThenInclude(y => y.Designation)
                .Include(x => x.IssueLog)
                    .ThenInclude(y => y.EntryBy)
                        .ThenInclude(z => z.Designation)
                .Include(x => x.IssueLog)
                        .ThenInclude(y => y.Project)
                        .   ThenInclude(k => k.Company)                    
                .ToList();
            return issueLogInvolvedPersons;
        }

        public async Task UpdateIssueLog(IssueLogInvolvedPerson issueLogInvolvedPerson)
        {
            _context.IssueLogInvolvedPerson.Update(issueLogInvolvedPerson);
            await _context.SaveChangesAsync();
        }
    }
}
