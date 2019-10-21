using IssueTracker.Data;
using IssueTracker.Data.Interfaces;
using IssueTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Service.Services
{
    public class CompanyService : ICompany
    {
        private readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var company = _context.Company.Where(x => x.Id == id).FirstOrDefault();
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Company company)
        {
            _context.Company.Update(company);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Company> GetAll()
        {
            var posts = _context.Company.ToList();
            return posts;
        }

        public Company GetById(int id)
        {
            var post = _context.Company.Where(x => x.Id == id).FirstOrDefault();
            return post;
        }
    }
}
