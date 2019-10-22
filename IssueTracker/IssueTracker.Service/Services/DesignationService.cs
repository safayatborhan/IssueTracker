using IssueTracker.Data;
using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Service.Services
{
    public class DesignationService : IDesignation
    {
        private readonly ApplicationDbContext _context;
        public DesignationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Designation designation)
        {
            _context.Designation.Add(designation);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var designation = _context.Designation.Where(x => x.Id == id).FirstOrDefault();
            _context.Designation.Remove(designation);
            _context.SaveChanges();
        }

        public async Task Edit(Designation designation)
        {
            _context.Designation.Update(designation);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Designation> GetAll()
        {
            var designations = _context.Designation.ToList();
            return designations;
        }

        public Designation GetById(int id)
        {
            var designation = _context.Designation.Where(x => x.Id == id).FirstOrDefault();
            return designation;
        }
    }
}
