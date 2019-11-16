using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssueTracker.Models;
using Microsoft.AspNetCore.Identity;
using IssueTracker.Data;
using IssueTracker.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace IssueTracker.Controllers
{
    public class HomeController : Controller
    {
        private static UserManager<ApplicationUser> _userManager;
        private readonly IInvolvedPerson _involvedPersonService;

        public HomeController(IInvolvedPerson involvedPersonService, UserManager<ApplicationUser> userManager)
        {
            _involvedPersonService = involvedPersonService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var involvedPersons = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == false).OrderBy(x => x.IssueLog.IssueDate);
            var involvedPersonsCompleted = _involvedPersonService.GetAllLogs(userId).Where(x => x.IsComplete == true);
            var model = BuildHomeIssueLogIndex(involvedPersons, involvedPersonsCompleted);
            return View(model);
        }

        private IssueLogHomeIndexModel BuildHomeIssueLogIndex(IOrderedEnumerable<IssueLogInvolvedPerson> involvedPersons, IEnumerable<IssueLogInvolvedPerson> involvedPersonsCompleted)
        {
            var deadlineMissedIssues = involvedPersons.Where(x => x.IssueLog.IssueDate.Date < DateTime.Now.Date).ToList();
            var todaysIssues = involvedPersons.Where(x => x.IssueLog.IssueDate.Date == DateTime.Now.Date).ToList();
            var upcomingIssues = involvedPersons.Where(x => x.IssueLog.IssueDate.Date > DateTime.Now.Date).ToList();
            var previousIssues = involvedPersonsCompleted.Where(x => (x.SubmitDate.Date >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date && x.SubmitDate.Date < DateTime.Now.Date)).ToList();

            //Chart start
            var lstModel = new List<WorkListForChartViewModel>();
            //sales of product sales by quarter
            for(DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date; date < DateTime.Now.Date; date = date.AddDays(1))
            {
                var previousIssuesByDate = previousIssues.Where(x => x.SubmitDate.Date == date).ToList();
                lstModel.Add(new WorkListForChartViewModel
                {
                    DateOfMonth = date.ToString("dd MMM"),
                    LstProjectHour = previousIssuesByDate.Select(x => new ProjectWiseWorkList
                    {
                        ProjectName = x.IssueLog.Project.Name + "(" + x.IssueLog.Project.Company.Name + ")",
                        Hour = x.HoursToComplete
                    })
                    //LstProjectHour = new List<ProjectWiseWorkList>()
                    //{
                    //    new ProjectWiseWorkList()
                    //    {
                    //        ProjectName="Payroll",
                    //        Hour = 2
                    //    },
                    //    new ProjectWiseWorkList()
                    //    {
                    //        ProjectName="TOM",
                    //        Hour = 3
                    //    },
                    //    new ProjectWiseWorkList()
                    //    {
                    //        ProjectName="Training",
                    //        Hour = 4
                    //    }
                    //}
                });
            }
            
            //Chart end

            var model = new IssueLogHomeIndexModel
            {
                WelcomeMessage = "Good " + ((DateTime.Now.TimeOfDay >= TimeSpan.Parse("4:00") && DateTime.Now.TimeOfDay <= TimeSpan.Parse("12:00")) ? "morning" : (DateTime.Now.TimeOfDay >= TimeSpan.Parse("12:01") && DateTime.Now.TimeOfDay <= TimeSpan.Parse("16:00") ? "afternoon" : "evening")) + " " + _userManager.GetUserName(User).ToString() + "!!",
                DeadlineMissedCount = deadlineMissedIssues.Count,
                DeadlineMissedIssues = deadlineMissedIssues.Select(x => new DeadlineMissedIssue
                {
                    Text = x.IssueLog.Header + "(" + x.IssueLog.Project.Name + " - " + x.IssueLog.Project.Company.Name + ")"
                }),
                TodaysIssueCount = todaysIssues.Count,
                TodaysIssues = todaysIssues.Select(x => new TodaysIssue
                {
                    Text = x.IssueLog.Header + "(" + x.IssueLog.Project.Name + " - " + x.IssueLog.Project.Company.Name + ")"
                }),
                UpcomingIssueCount = upcomingIssues.Count,
                UpcomingIssues = upcomingIssues.Select(x => new UpcomingIssue
                {
                    Text = x.IssueLog.Header + "(" + x.IssueLog.Project.Name + " - " + x.IssueLog.Project.Company.Name + ")"
                }),
                WorkListForChart = lstModel
            };
            return model;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
