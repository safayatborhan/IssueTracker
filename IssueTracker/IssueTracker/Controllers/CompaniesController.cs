using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Data;
using IssueTracker.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IssueTracker.Models;

namespace IssueTracker.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static UserManager<ApplicationUser> _userManager;

        public CompaniesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Company.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.Where(m => m.Id == id)
                .Include(m => m.CreatedBy)
                .Include(m => m.ModifiedBy)
                .FirstOrDefaultAsync();

            if (company == null)
            {
                return NotFound();
            }
            var model = BuilCompanyDetailModel(company);
            return View(model);
        }

        // GET: Companies/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Status")] Company company)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                company.CreatedBy = user;
                company.CreationDate = DateTime.Now;
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.Where(x => x.Id == id).Include(x => x.CreatedBy).FirstOrDefaultAsync();
            var model = BuildCompanyEditModel(company);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyEditModel companyModel)
        {
            if (id != companyModel.Id)
            {
                return NotFound();
            }
             
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = _userManager.GetUserId(User);
                    companyModel.ModifiedBy = userId;
                    companyModel.ModifiedDate = DateTime.Now;
                    var company = BuildCompanyModel(companyModel);
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(companyModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(companyModel);
        }

        // GET: Companies/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Companies/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }

        private Company BuildCompanyModel(CompanyEditModel model)
        {
            var createdBy = _userManager.FindByIdAsync(model.CreatedBy).Result;
            var modifiedBy = _userManager.FindByIdAsync(model.ModifiedBy).Result;
            var company = new Company
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                Status = model.Status,
                CreatedBy = createdBy,
                CreationDate = model.CreatedDate,
                ModifiedBy = modifiedBy,
                ModifiedDate = (DateTime)model.ModifiedDate
            };
            return company;
        }

        private CompanyEditModel BuildCompanyEditModel(Company company)
        {
            var model = new CompanyEditModel
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                Status = company.Status,
                CreatedBy = company.CreatedBy != null ? company.CreatedBy.Id : string.Empty,
                CreatedDate = company.CreationDate,
                ModifiedBy = company.ModifiedBy != null ? company.ModifiedBy.Id : string.Empty,
                ModifiedDate = company.ModifiedDate != null || company.ModifiedDate != DateTime.MinValue ? (DateTime?)company.ModifiedDate : null
            };
            return model;
        }

        private CompanyDetaiModel BuilCompanyDetailModel(Company company)
        {
            var model = new CompanyDetaiModel
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                Status = company.Status.ToString(),
                CreatedBy = company.CreatedBy != null ? company.CreatedBy.UserName : string.Empty,
                CreatedDate = company.CreationDate != DateTime.MinValue ? company.CreationDate.ToString("dd MMM yyyy") : string.Empty,
                ModifiedBy = company.ModifiedBy != null ? company.ModifiedBy.UserName : string.Empty,
                ModifiedDate = company.ModifiedDate != DateTime.MinValue ? company.ModifiedDate.ToString("dd MMM yyyy") : string.Empty
            };
            return model;
        }
    }
}
