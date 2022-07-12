using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CarGuru.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _service;
        private readonly ISessionManager _session;
        private readonly ILookUpsService _LookupService;
        private readonly IWebHostEnvironment _webHost;
        public UserProfileController(IWebHostEnvironment webHost, ILookUpsService LookupService, IUserProfileService service, ISessionManager session)
        {
            _service = service;
            _session = session;
            _LookupService = LookupService;
            _webHost = webHost;
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            UserViewModel vm = new UserViewModel();
            var userId = _session.GetUserId();
            
            var Genders = _LookupService.GetLookupValueWithType("Gender");
            if (Genders.Status is 1)
                if (Genders.Data.Any())
                    vm.Genders.AddRange(Genders.Data.Select(item => new SelectListItem { Text = item.LookupTitle, Value = item.Id.ToString() }));

            vm.User = await _service.GetByUserId(userId);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserViewModel vm)
        {
            
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                foreach (var source in files)
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString();
                    string Name = source.FileName;
                    filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(Name);
                    string extension = System.IO.Path.GetExtension(filename);

                    var filePath = "/ProfilePics/" + filename;
                    vm.User.ProfileUrl = EnviromentUrls.Url + filePath;

                    await using (FileStream output = System.IO.File.Create(this.GetFullPath(filename)))
                        await source.CopyToAsync(output);
                };
            }
            var userId = _session.GetUserId();
            vm.User.UserId = userId;
            var result = _service.UpdateProfile(vm.User);
            vm.User = result;
            var old = _session.GetProfilePicture();
            _session.SetProfilePicture(vm.User.ProfileUrl);
            var New = _session.GetProfilePicture();
            _session.SetUserName(vm.User.FirstName+" "+vm.User.LastName);
            return Json(vm.User.ProfileUrl);
        }
        private string GetFullPath(string filename)
        {
            return this._webHost.WebRootPath + "\\ProfilePics\\" + filename;
        }
    }
}
