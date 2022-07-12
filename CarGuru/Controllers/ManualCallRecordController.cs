using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Controllers
{
    public class ManualCallRecordController : Controller
    {
        private readonly IManualCallRecordService _service;
        private readonly ISessionManager _session;
        public ManualCallRecordController(IManualCallRecordService service, ISessionManager session)
        {
            _session = session;
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CallRecords()
        {
            CallRecordsViewModel vm = new CallRecordsViewModel();
            var List = await _service.List("");
            vm.Records = List.Data;
            return View(vm);
        }
        public async Task<IActionResult> Search(string Name)
        {
            CallRecordsViewModel vm = new CallRecordsViewModel();
            var List = await _service.List(Name);
            vm.Records = List.Data;
            return PartialView("~/Views/ManualCallRecord/_RecordsList.cshtml", vm);
        }
        public async Task<IActionResult> DeleteRecord(long Id)
        {
            CallRecordsViewModel vm = new CallRecordsViewModel();
            var List = await _service.DeleteRecord(Id);
            vm.Records = List.Data;
            return PartialView("~/Views/ManualCallRecord/_RecordsList.cshtml", vm);
        }
        public async Task<IActionResult> GetRecordById(int Id)
        {
            return Json(await _service.GetByIdAsync(Id));
        }
        public async Task<IActionResult> RecordAddOrEdit(CallRecordsViewModel model)
        {
            if (model.Record.Id > 0)
            {
                var List = await _service.UpdateAsync(model.Record);
                model.Records = List.Data;
                return PartialView("~/Views/ManualCallRecord/_RecordsList.cshtml", model);
            }
            model.Record.CreatedBy = _session.GetUserId();
            var result = await _service.CreateAsync(model.Record);
            model.Records = result.Data;
            return PartialView("~/Views/ManualCallRecord/_RecordsList.cshtml", model);
        }
    }
}