using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.Controllers
{
    [Authorize]
    public class CommonController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionManager _sessionManager;

        public CommonController(IUserService userService,ISessionManager sessionManager)
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetContactsByRoleId(int roleId)
        {
            var ContactList = new List<SelectListItem>();
            long LogedInUser = _sessionManager.GetUserId();
        var Contacts = _userService.UsersChatListByRoleId(roleId);
            
            if (Contacts.Status is 1)
                if (Contacts.Data.Any())
                    ContactList.AddRange(Contacts.Data.Select(item => new SelectListItem { Text = item.FirstName+' '+item.LastName, Value = item.UserId.ToString() }));
            return PartialView("~/Views/Shared/_ContactTypeList.cshtml",ContactList);
        }
        
    }
}