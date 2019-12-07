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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>().HasOne<ApplicationUser>(a => a.Sender).WithMany(b => b.Messages).HasForeignKey(b => b.UserId);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }        
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<IssueLog> IssueLog { get; set; }
        public DbSet<IssueLogInvolvedPerson> IssueLogInvolvedPerson { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ProjectSupportPerson> ProjectSupportPerson { get; set; }
        public DbSet<ProjectContactPerson> ProjectContactPerson { get; set; }
        public DbSet<ProjectWiseStatus> ProjectWiseStatus { get; set; }
    }
}
