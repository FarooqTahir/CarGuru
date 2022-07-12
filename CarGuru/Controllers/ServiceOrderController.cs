using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Controllers
{
    public class ServiceOrderController : Controller
    {
        private readonly IServiceOrderService _service;

        public ServiceOrderController(IServiceOrderService ServiceOrderService)
        {
            _service = ServiceOrderService;   
        }
        public async Task<IActionResult> SearchOrders(string Name)
        {
            var vm = new CustomerViewModel();
            var result = await _service.SearchOrder(Name);
            vm.CustomerOrders = result;
            return PartialView("~/Views/Management/_OrderListing.cshtml", vm);
        }

    }
}