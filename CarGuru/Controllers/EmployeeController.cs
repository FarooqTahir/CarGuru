using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILookUpsService _lookUpsService;
        public EmployeeController(ILookUpsService lookUpsService, IEmployeeService employeeService)
        {
            _lookUpsService = lookUpsService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Employees()
        {
            var model = new EmployeeViewModel();
            var listResponse = _lookUpsService.GetAllRoles();
            listResponse.Data = listResponse.Data.Where(a => !(a.RoleName.Equals("Customer"))).ToList();
            if (listResponse.Status is 1)
                if (listResponse.Data.Any())
                    model.EmployeeTypes.AddRange(listResponse.Data.Select(item => new SelectListItem { Text = item.RoleName, Value = item.Id.ToString() }));
            var dataList = await _employeeService.GetAllAsync("");
            model.EmployeesList = dataList.Data;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SearchEmployee(string Name)
        {
            var model = new EmployeeViewModel();
            var dataList = await _employeeService.GetAllAsync(Name);
            model.EmployeesList = dataList.Data;

            return PartialView("~/Views/Employee/PartialViews/_EmployeeList.cshtml", model);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeAddOrEdit(EmployeeViewModel model)
        {
            
            if (model.EmployeeRequestDto.User.UserId > 0)
            {
                var List = await _employeeService.UpdateAsync(model.EmployeeRequestDto);
                model.EmployeesList = List.Data;
                return PartialView("~/Views/Employee/PartialViews/_EmployeeList.cshtml", model);
            }
            model.EmployeeRequestDto.User.Password = Common.RandomPassword(8);
            model.EmployeeRequestDto.User.ConfirmPassword = model.EmployeeRequestDto.User.Password;
            var result = await _employeeService.CreateAsync(model.EmployeeRequestDto);
            model.EmployeesList = result.Data;
            return PartialView("~/Views/Employee/PartialViews/_EmployeeList.cshtml", model); 
        }

        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            return Json(await _employeeService.GetByIdAsync(employeeId));
        }

        public async Task<IActionResult> DeleteEmployee(long Id)
        {
            var vm = new EmployeeViewModel();
            var List = await _employeeService.DeleteEmployee(Id);
            vm.EmployeesList = List.Data;
            return PartialView("~/Views/Employee/PartialViews/_EmployeeList.cshtml", vm);
        }

    }
}