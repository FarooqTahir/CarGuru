using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.Controllers
{
    public class FleetController : Controller
    {
        private readonly IFleetService _service;
        private readonly ILookUpsService _lookUpsService;
        public FleetController(ILookUpsService lookUpsService, IFleetService service)
        {
            _lookUpsService = lookUpsService;
            _service = service;
        }
        public async Task<IActionResult> Fleet()
        {
            var model = new FleetViewModel();
            var listResponse = _lookUpsService.GetAllRoles();
            var dataList = await _service.GetAllAsync();
            model.FleetList = dataList.Data;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FleetAddOrEdit(FleetViewModel model)
        {
            var vm = new FleetViewModel();
            if (model.Fleet.Id > 0)
            {
                var List = await _service.UpdateAsync(model.Fleet);
                vm.FleetList = List.Data;
                return PartialView("~/Views/Fleet/PartialViews/_FleetListing.cshtml", vm);
            }
            var result = await _service.CreateAsync(model.Fleet);
            vm.FleetList = result.Data;
            return PartialView("~/Views/Fleet/PartialViews/_FleetListing.cshtml", vm);
        }

        public async Task<IActionResult> GetFleetById(int FleetId)
        {
            return Json(await _service.GetByIdAsync(FleetId));
        }

        public async Task<IActionResult> DeleteFleet(long Id)
        {
            var vm = new FleetViewModel();
            var List = await _service.DeleteAsync(Id);
            vm.FleetList = List.Data;
            return PartialView("~/Views/Fleet/PartialViews/_FleetListing.cshtml", vm);
        }
    }
}