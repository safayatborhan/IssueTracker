using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueTracker.Data;
using IssueTracker.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class ChatterController : Controller
    {
        private static UserManager<ApplicationUser> _userManager;
        private readonly IChat _chatService;
        public ChatterController(IChat chatService, UserManager<ApplicationUser> userManager)
        {
            _chatService = chatService;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            var messages = _chatService.GetAll(); 
            return View();
        }

        public IActionResult Create(Message message)
        {
            if(ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                message.When = DateTime.Now;
                message.Sender = user;
                message.UserName = user.UserName;
                message.UserId = user.Id;                
                _chatService.AddMessage(message);
                return Ok();
            }
            return View(message);
        }
    }
}