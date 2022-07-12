using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.Controllers
{
    [Authorize]
    public class SupervisorController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IServiceOrderService _serviceOrderService;
        private readonly ILookUpsService _lookupService;
        private readonly ICustomerService _customerService;
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly ISessionManager _session;
        private readonly IAgentService _agent;
        public SupervisorController(ICustomerTypeService customerTypeService,IProductService productService,IProductCategoryService productCategoryService,ICustomerService customerService, ILookUpsService lookupService,IEmployeeService employeeService, IServiceOrderService serviceOrderService, ISessionManager session, IAgentService agent)
        {
            _employeeService = employeeService;
            _serviceOrderService= serviceOrderService;
            _lookupService = lookupService;
            _customerService = customerService;
            _productCategoryService = productCategoryService;
            _productService = productService;
            _customerTypeService = customerTypeService;
            _session = session;
            _agent = agent;
        }
        public async Task<IActionResult> Leads(long? AgentId)
        {
            SupervisorViewModel vm = new SupervisorViewModel();
            var result = await _serviceOrderService.GetAllLeads(AgentId);
            vm.Leads = result;
            ViewBag.Leads = "active";
            return View(vm);
        }

        public async Task<IActionResult> ProductDashboard()
        {
            var vm = new ProductViewModel();
            var types = _productCategoryService.GetAllAsync();

            var dbList = await _productService.GetAllAsync("");
            var ListResult = _productCategoryService.GetAllAsync();
            vm.Categories = ListResult.Data;
            vm.Products = dbList.Data.OrderByDescending(d => d.CreatedDate).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Orders()
        {
            var vm = new CustomerViewModel();
            var result = await _customerService.GetAllServicecOrderList();
            vm.CustomerOrders = result;
            return View(vm);
        }

        public IActionResult Notification()
        {
            ViewBag.Notification = "active";
            return View();
        }
        public async Task<IActionResult> Agents()
        {
            var vm = new SupervisorViewModel();
            ViewBag.Notification = "active";
            vm.Agents = await _employeeService.GetAllAgents();

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AgentAddOrEdit(SupervisorViewModel model)
        {

            if (model.Agent.User.UserId > 0)
            {
                var List = await _employeeService.UpdateAsync(model.Agent);
                model.Agents = await _employeeService.GetAllAgents();
                return PartialView("~/Views/Supervisor/_AgentsListing.cshtml", model);
            }
            model.Agent.User.Password = Common.RandomPassword(8);
            model.Agent.User.ConfirmPassword = model.Agent.User.Password;
            model.Agent.User.RoleId=2;

            var result = await _employeeService.CreateAsync(model.Agent);
            model.Agents = await _employeeService.GetAllAgents();
            return PartialView("~/Views/Supervisor/_AgentsListing.cshtml", model);
        }
        public async Task<IActionResult> ServiceOrderList(long AgentId)
        {
            var vm = new SupervisorViewModel();
            vm.Orders = await _serviceOrderService.GetAllServicecOrderListByAgentId(AgentId);
            var result = _lookupService.GetUserByUserId(AgentId);
            vm.AgentName = result.Data.FirstName + " " + result.Data.LastName;
            return View(vm);
        }
        //public IActionResult Dashboard()
        //{
        //    ViewBag.Dashboard = "active";
        //    return View();
        //}
        public async Task<IActionResult> Dashboard()
        {
            var vm = new CustomerViewModel();
            var response = await _agent.AgentDashboardAnalytics(null, null, null);
            vm.Analytics = response.Data;
            ViewBag.Dashboard = "active";
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DashboardAnalyticsFilter(DateTime? startDate, DateTime? endDate)
        {
            var vm = new CustomerViewModel();
            var response = await _agent.AgentDashboardAnalytics(null, startDate, endDate);
            vm.Analytics = response.Data;
            return PartialView("~/Views/Supervisor/_SupervisorDashboard.cshtml", vm);
        }
        public IActionResult _AddNewCustomer()
        {

            return View();
        }
        public IActionResult _CustomerDetail()
        {

            return View();
        }
        public async Task<IActionResult> Customer()
        {
            CustomerViewModel vm = new CustomerViewModel();
            var types = await _customerTypeService.GetAllAsync();
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.CustomerTypes.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            vm.CustomerList = _customerService.GetAllCustomer("");
            return View(vm);
        }

        public IActionResult Scheduler()
        {
            ViewBag.Scheduler = "active";
            return View();
        }
        public async Task<IActionResult> GetAllServiceOrders()
        {
            var result = await _serviceOrderService.GetAlllistForCalanders(null, null);
           
            return Json(result);
        }
    }

}