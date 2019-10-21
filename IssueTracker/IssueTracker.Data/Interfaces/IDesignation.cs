using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data
{
    public interface IDesignation
    {
        Designation GetById(int id);
        IEnumerable<Designation> GetAll();
        Task Create(Designation designation);
        Task Edit(Designation designation);
        Task Delete(int id);
    }
}
