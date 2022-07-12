using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }
        [HttpPost]
        public async Task<IActionResult> AddVendor(ManagementViewModel model)
        {
            if(model.Vendor.Id == 0)
            {
                var response = await _vendorService.CreateAsync(model.Vendor);
                return PartialView("~/Views/Management/_VendorList.cshtml", response.Data);
            }
            else
            {
                var respsonse = await _vendorService.UpdateAsync(model.Vendor);
                return PartialView("~/Views/Management/_VendorList.cshtml", respsonse.Data);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> ArchiveVendor(int vendorId)
        {
            var respsonse = await _vendorService.DeleteAsync(vendorId);
            return PartialView("~/Views/Management/_VendorList.cshtml", respsonse.Data);
        }

        public async Task<IActionResult> GetVendorById(int vendorId)
        {
            var respsonse = await _vendorService.GetByIdAsync(vendorId);
            return Json(respsonse);
        }
        
    }
}