using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILookUpsService _lookService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly IVendorService _vendorService;
        private readonly IServiceOrderService _ServiceOrderService;
        private readonly ISessionManager _session;
        private readonly IAgentService _agent;

        public AgentController(ISessionManager session,IServiceOrderService ServiceOrderService,IVendorService vendorService,IUserService userService, ILookUpsService lookService, IProductCategoryService productCategoryService, IProductService productService,IAgentService agent)
        {
            _userService = userService;
            _vendorService = vendorService;
            _lookService = lookService;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _session = session;
            _ServiceOrderService = ServiceOrderService;
            _agent = agent;
        }

        public async Task<IActionResult> Orders()
        {
            var vm = new CustomerViewModel();
            var UserId = Convert.ToInt32(_session.GetUserId());
            var result = await _ServiceOrderService.GetAllServicecOrderListByAgentId(UserId);
            vm.CustomerOrders = result;
            return View(vm);
        }
        public async Task<IActionResult> Leads()
        {
            AgentViewModel vm = new AgentViewModel();
            var AgentId = _session.GetUserId();
            var result = await _ServiceOrderService.GetAllLeads(AgentId);
            vm.Leads = result;
            ViewBag.Leads = "active";
            return View(vm);
        }

        public IActionResult Notification()
        {
            ViewBag.Notification = "active";
            return View();
        }
        

        [HttpPost]
        public IActionResult LoginAccess(string userName, string Password)
         {
            if (userName == "agent@gmail.com" && Password == "12345")
            {
                return RedirectToAction("Dashboard", "Agent");
            }
         
            else if (userName == "management@gmail.com" && Password =="12345")
            {

                return RedirectToAction("Dashboard", "Management");
            }
            else if (userName == "supervisor@gmail.com" && Password == "12345")
            {

                return RedirectToAction("Dashboard", "Supervisor");
            }
            else
            {
                  return View("Login");
            }
          
        }

        public IActionResult Customer()
        {
            ViewBag.Leads = "active";
            return View();
        }

        public async Task<IActionResult> ProductDashboard()
        {
            var vm = new ProductViewModel();
            var types = _productCategoryService.GetAllAsync();
            var vendors = await _vendorService.GetAllAsync();
            if (types.Status is 1)
                if (vendors.Data.Any())
                    vm.Vendors.AddRange(vendors.Data.Select(item => new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString() }));
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.ProductCategories.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            var dbList = await _productService.GetAllAsync("");
            var ListResult = _productCategoryService.GetAllAsync();
            vm.Categories = ListResult.Data;
            vm.Products = dbList.Data.OrderByDescending(d => d.CreatedDate).ToList();
            return View(vm);
        }
        
        
       
        public async Task<IActionResult> Dashboard()
        {
            var vm = new CustomerViewModel();
            var UserId = Convert.ToInt32(_session.GetUserId());
            var response = await _agent.AgentDashboardAnalytics(UserId, null, null);
            vm.Analytics = response.Data;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DashboardAnalyticsFilter(DateTime?startDate,DateTime? endDate)
        {
            var vm = new CustomerViewModel();
            var UserId = Convert.ToInt32(_session.GetUserId());
            var response = await _agent.AgentDashboardAnalytics(UserId, startDate, endDate);
            vm.Analytics = response.Data;
            return PartialView("~/Views/Agent/_AgentDashboard.cshtml",vm);
        }
        public IActionResult Scheduler()
        {
            return View();
        }
        public async Task<IActionResult> GetAllServiceOrders()
        {
            var AgentId = _session.GetUserId(); 
            var result = await _ServiceOrderService.GetAlllistForCalanders(AgentId,null);

            return Json(result);
        }



    }
 
}