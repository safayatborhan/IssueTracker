using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data
{
    public interface IInvolvedPerson
    {
        IEnumerable<IssueLogInvolvedPerson> GetAllLogs(string userId);
        Task UpdateIssueLog(IssueLogInvolvedPerson issueLogInvolvedPerson);
    }
}
