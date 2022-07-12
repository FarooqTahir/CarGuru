using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.Dtos;
using CarGuru.Models;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private readonly IVendorService _vendorService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IQuotationService _quotationService;
        private readonly ILookUpsService _lookUpsService;
        private readonly IManagementService _managementService;
        private readonly IUserService _userService;

        private readonly ISessionManager _session;
        private readonly INotificationService _notification;
        public ManagementController(IProductCategoryService productCategoryService,
            IVendorService vendorService,
            ICustomerService customerService,
            IProductService productService,
            ISessionManager session,
            INotificationService notification,
            IQuotationService quotationService,
            ILookUpsService lookUpsService,
            IManagementService managementService,
            IUserService userService)
        {
            _productCategoryService = productCategoryService;
            _vendorService = vendorService;
            _productService = productService;
            _customerService = customerService;
            _quotationService = quotationService;
            _lookUpsService = lookUpsService;
            _userService = userService;
            _managementService = managementService;
            _notification = notification;
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customer()
        {
            ViewBag.Leads = "active";
            return View();
        }

        public async Task<IActionResult> Report()
        {
            var model = new ManagementViewModel();
            model.ReportStat = await _managementService.GetManagmentReports();
            ViewBag.Report = "active";
            return View(model);
        }

        public async Task<IActionResult> Inventory()
        {
            var vm = new ProductViewModel();
            var types = _productCategoryService.GetAllAsync();
            var subtypes = await _productCategoryService.GetAllSubCategoryIdCategoryIdAsync(0);
            var vendors = await _vendorService.GetAllAsync();
            var fleets = _productService.GetAllFleets();
            if (fleets.Status is 1)
                if (fleets.Data.Any())
                    vm.Fleets.AddRange(fleets.Data.Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() }));
            if (vendors.Status is 1)
                if (vendors.Data.Any())
                    vm.Vendors.AddRange(vendors.Data.Select(item => new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString() }));
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.ProductCategories.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            var dbList = await _productService.GetAllAsync("");
            vm.Products = dbList.Data.OrderByDescending(d => d.CreatedDate).ToList();
            return View(vm);
        }
        public async Task<IActionResult> SearchInventory(string Name)
        {
            var vm = new ProductViewModel();
           
            var dbList = await _productService.GetAllAsync(Name);
            vm.Products = dbList.Data.OrderByDescending(d => d.CreatedDate).ToList();
            return PartialView("~/Views/Management/_InventoryList.cshtml", vm);
        }
        [HttpPost]
        public async Task<IActionResult> GetSubCategories(int categoryId)
        {
            List<SelectListItem> SubCategories = new List<SelectListItem>();
        var dbList = await _productCategoryService.GetAllSubCategoryIdCategoryIdAsync(categoryId);
            if (dbList.Status is 1)
                if (dbList.Data.Any())
                    SubCategories.AddRange(dbList.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));
            return PartialView("~/Views/Management/_SubCategoryList.cshtml", SubCategories);
        }

        public async Task<IActionResult> Quotations()
        {
            QuotationViewModel vm = new QuotationViewModel();
            vm.QuotationRequests = await _quotationService.GetQuotationRequestList("");
            ViewBag.Quotations = "active";
            return View(vm);
        }

        public async Task<IActionResult> GetQuotationInfoById(long quotationId,bool isView = true)
        {
            QuotationViewModel vm = new QuotationViewModel();
            vm.IsView = isView;
            var Products = _lookUpsService.GetAllProductsList();
            if (Products.Status is 1)
                if (Products.Data.Any())
                    vm.Products.AddRange(Products.Data.Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() }));
             vm.QuotationDetail = await _quotationService.GetQuotationDetailByQuotationId(quotationId);
            return PartialView("~/Views/Management/_QuotationDetail.cshtml", vm);
        }

        public async Task<IActionResult> UpdateQuotationProduct(long quotationDetailId,long productId,long quotationId)
        {
            var ProductPrice = await _quotationService.UpdateQuotationProduct(quotationId, quotationDetailId,productId);
            return Json(ProductPrice);
        }

        public IActionResult Employee()
        {
            ViewBag.Employee = "active";
            return View();
        }

        public IActionResult ProductDashboard()
        {
            ViewBag.ProductDashboard = "active";
            return View();
        }

        public IActionResult Notification()
        {
            ViewBag.Notification = "active";
            return View();
        }

        public async Task<IActionResult> Orders()
        {
            var vm = new CustomerViewModel();
            var result = await _customerService.GetAllServicecOrderList();
            vm.CustomerOrders = result;
            return View(vm);
        }

        public IActionResult History()
        {
            ViewBag.History = "active";
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            ManagementViewModel model = new ManagementViewModel();
            ViewBag.Dashboard = "active";
            model.ManagementStat = await _managementService.ManagementDashboardAnalytics(null, null);
            var Technician = _userService.UsersListByRoleId(5);
            if (Technician.Status is 1)
                if (Technician.Data.Any())
                    model.TechnicianList.AddRange(Technician.Data.Select(item => new SelectListItem { Text = item.FirstName, Value = item.UserId.ToString() }));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GetTechnicianStat(long? technicianId)
        {
            ManagementViewModel model = new ManagementViewModel();
            model.TechnicianStat = await _managementService.TechnicianStatData(technicianId);
            return PartialView("~/Views/Management/_TechnicianStat.cshtml",model);
        }
        [HttpPost]
        public async Task<IActionResult> DashboardManagementFilter(DateTime? startDate, DateTime? endDate)
        {
            ManagementViewModel model = new ManagementViewModel();
            ViewBag.Dashboard = "active";
            model.ManagementStat = await _managementService.ManagementDashboardAnalytics(startDate, endDate);
            var Technician = _userService.UsersListByRoleId(5);
            if (Technician.Status is 1)
                if (Technician.Data.Any())
                    model.TechnicianList.AddRange(Technician.Data.Select(item => new SelectListItem { Text = item.FirstName, Value = item.UserId.ToString() }));
            return PartialView("~/Views/Management/_ManagementDashboardStat.cshtml", model);
        }
        public async Task<IActionResult> Vendor()
        {
            ViewBag.Vendor = "active";
            var vm = new ManagementViewModel();
            var response = await _vendorService.GetAllAsync();
            if (response.Data.Any()) vm.Vendors = response.Data;
            return View(vm);
        }
        public async Task<IActionResult> ForwardQuotationToClient(long UserId,string Description,long QoutationId) 
        {
            QuotationViewModel vm = new QuotationViewModel();
            NotificationDto n = new NotificationDto();
            PushQueueDto pn = new PushQueueDto();
            n.NotificationTo = UserId;
            n.NotificationFrom = _session.GetUserId();
            n.Message = PushNotifications.QuotaionNotification;
            n.TypeId = Convert.ToInt32(NotificationTypes.QuotationRequestIsReviewed);
            await _notification.Create(n);

            var List = await _userService.GetUserDevices(UserId);
            foreach (var item in List.Data)
            {
                var resp = Common.SendPushNotification(item.DeviceToken, PushNotifications.QuotaionNotification);
                pn.Body = resp.RequestString;
                pn.IsSent = true;
                if (resp.Status == "0") { pn.IsSent = false; }
                if (resp != null) 
                {
                    await _notification.CreatePushQueue(pn);
                }
            }            
            _quotationService.AddDescription(Description, QoutationId);
            vm.QuotationRequests = await _quotationService.GetQuotationRequestList("");
            var x = vm.QuotationRequests.Data.Where(x => x.QuotationId == 62).FirstOrDefault();
            return PartialView("~/Views/Management/_QoutationList.cshtml", vm);
        }
        public async Task<IActionResult> SearchQuotation(string Name)
        {
            QuotationViewModel vm = new QuotationViewModel();
            vm.QuotationRequests = await _quotationService.GetQuotationRequestList(Name);
            return PartialView("~/Views/Management/_QoutationList.cshtml", vm);
        }
        public IActionResult _AddNewCustomer()
        {
            
            return View();
        }

        public IActionResult _CustomerDetail()
        {

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Scheduler()
        {
            return View();
        }

        public IActionResult Invoice()
        {
            return View();
        }

        public IActionResult ReportMonthly()
        {
            return View();
        }
    }
}