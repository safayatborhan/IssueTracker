using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data.Interfaces
{
    public interface ICompany
    {
        Company GetById(int id);
        IEnumerable<Company> GetAll();
        Task Create(Company company);
        Task Edit(Company company);
        Task Delete(int id);
    }
}
