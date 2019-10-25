using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data
{
    public interface IProject
    {
        Project GetById(int id);
        IEnumerable<Project> GetAll();
        Task Create(Project Project);
        Task Edit(Project Project);
        void Delete(int id);

        Company GetCompanyById(int id);
        IEnumerable<Company> GetAllCompanies();
    }
}
