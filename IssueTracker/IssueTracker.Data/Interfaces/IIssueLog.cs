using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data
{
    public interface IIssueLog
    {
        IssueLog GetById(int id);
        IEnumerable<IssueLog> GetAll();
        Task Create(IssueLog Project);
        Task Edit(IssueLog Project);
        void Delete(int id);

        Task AddInvolvedPersons(IEnumerable<IssueLogInvolvedPerson> issueLogInvolvedPersons);
        void RemoveInvolvedPerson(int issueLogId,int involvedPersonId);

    }
}
