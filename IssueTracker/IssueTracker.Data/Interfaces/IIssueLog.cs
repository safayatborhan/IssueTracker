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
        void Create(IssueLog Project);
        void Edit(IssueLog Project);
        void Delete(int id);

        Task AddInvolvedPersons(IEnumerable<IssueLogInvolvedPerson> issueLogInvolvedPersons);

    }
}
