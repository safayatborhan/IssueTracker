using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data
{
    public interface IProjectWiseStatus
    {
        IEnumerable<ProjectWiseStatus> GetAll();
        IEnumerable<ProjectWiseStatus> GetByProject(int ProjectId);
        void Create(ProjectWiseStatus ProjectWiseStatus);
    }
}
