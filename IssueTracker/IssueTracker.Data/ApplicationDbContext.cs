using IssueTracker.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }        
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<IssueLog> IssueLog { get; set; }
        public DbSet<IssueLogInvolvedPerson> IssueLogInvolvedPerson { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
