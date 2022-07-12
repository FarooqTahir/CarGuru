using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Services.Interfaces;
using CarGuru.Services.Services;
using CarGuru.Utilities;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarGuru.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IServiceOrderService _ServiceOrderService;
        private readonly ILookUpsService _lookUpsService;
        private readonly IUserService _userService;
        private readonly ISessionManager _session;
        private readonly IQuotationService _quotationService;
        private readonly INotificationService _notificationService;
        public CustomerController(
            ISessionManager session,
            IServiceOrderService ServiceOrderService,
            IUserService userService,
            IQuotationService quotationService,
            ICustomerService customerService,
            ILookUpsService lookUpsService,
            INotificationService notificationService,
            ICustomerTypeService customerTypeService)
        {
            _customerService = customerService;
            _customerTypeService = customerTypeService;
            _lookUpsService = lookUpsService;
            _ServiceOrderService = ServiceOrderService;
            _userService = userService;
            _quotationService = quotationService;
            _session = session;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> AddNewCustomer()
        {
            var vm = new CustomerViewModel();
            var types = await _customerTypeService.GetAllAsync();
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.CustomerTypes.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            var services = _lookUpsService.GetLookupValueWithType("ServiceType");
            if (services.Status is 1)
                if (services.Data.Any())
                    vm.ServiceTypes.AddRange(services.Data.Select(item => new SelectListItem { Text = item.LookupTitle, Value = item.Id.ToString() }));

            var Source = _lookUpsService.GetLookupValueWithType("Source");
            if (Source.Status is 1)
                if (Source.Data.Any())
                    vm.Sources.AddRange(Source.Data.Select(item => new SelectListItem { Text = item.LookupTitle, Value = item.Id.ToString() }));

            var Agents = _userService.UsersListByRoleId(Convert.ToInt32(UserRoles.Agent));
            if (Agents.Status is 1)
                if (Agents.Data.Any())
                    vm.Agents.AddRange(Agents.Data.Select(item => new SelectListItem { Text = item.FirstName, Value = item.UserId.ToString() }));

            var Technicians = _userService.UsersListByRoleId(Convert.ToInt32(UserRoles.Technician));
            if (Technicians.Status is 1)
                if (Technicians.Data.Any())
                    vm.Technicians.AddRange(Technicians.Data.Select(item => new SelectListItem { Text = item.FirstName, Value = item.UserId.ToString() }));

            var Products = _lookUpsService.GetAllProductsList();
            if (Products.Status is 1)
                if (Products.Data.Any())
                    vm.Products.AddRange(Products.Data.Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() }));

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerViewModel model)
        {
            model.CustomerVehicles = JsonConvert.DeserializeObject<List<CustomerVehicleRequestDto>>(model.Vehicles);
            model.Customer.User.RoleId = Convert.ToInt32(UserRoles.Customer);
            long CreatedbyId = Convert.ToInt32(_session.GetUserId());
            model.ServiceOrder.ScheduleDateTime = model.ServiceOrder.ScheduleDateTime + model.ServiceOrder.SchaduledTime;
            var response = await _customerService.CreateWithVehicles(model.Customer, model.CustomerVehicles, CreatedbyId);
            var Cars = _customerService.GetAllVehiclesByCustomerId(null, response.Data.Id);
            if (Cars.Status is 1)
                if (Cars.Data.Any())
                    model.VehicleDropdown.AddRange(Cars.Data.Select(item => new SelectListItem { Text = item.Make + "-" + item.Model + "-" + item.Year, Value = item.Id.ToString() }));
            model.CustomerId = response.Data.Id;
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CustomerViewModel model)
        {
            if (model.ServiceOrder.Id > 0)
            {
                model.ServiceOrder.ScheduleDateTime = model.ServiceOrder.ScheduleDateTime +model.ServiceOrder.SchaduledTime;
                model.ServiceOrder.Products = JsonConvert.DeserializeObject<List<ProductInServiceOrderDto>>(model.ProductsList);
                model.ServiceOrder.Services = JsonConvert.DeserializeObject<List<ServicesInServiceOrderDto>>(model.ServicesList);
                var UserId = _session.GetUserId();
                //await SendNotification(model.ServiceOrder.AssignedToId.Value,NotificationTypes.NewOrderAssigned.ToString(),Convert.ToInt32(NotificationTypes.NewOrderAssigned));
                //await SendNotification(model.ServiceOrder.AssignedToId.Value, NotificationTypes.TechnicianAssignedToOrder.ToString(), Convert.ToInt32(NotificationTypes.TechnicianAssignedToOrder));
                var response = _customerService.EditServiceOrder(model.ServiceOrder,UserId);
                return Json(response.Data.UserId );
            }
            else 
            {
                model.ServiceOrder.ScheduleDateTime = model.ServiceOrder.ScheduleDateTime + model.ServiceOrder.SchaduledTime;
                model.ServiceOrder.Products = JsonConvert.DeserializeObject<List<ProductInServiceOrderDto>>(model.ProductsList);
                model.ServiceOrder.Services = JsonConvert.DeserializeObject<List<ServicesInServiceOrderDto>>(model.ServicesList);
                var UserId = _session.GetUserId();
                await SendNotification(model.ServiceOrder.AssignedToId.Value, NotificationTypes.NewOrderAssigned.ToString(), Convert.ToInt32(NotificationTypes.NewOrderAssigned));
                //await SendNotification(model.ServiceOrder.AssignedToId.Value, NotificationTypes.TechnicianAssignedToOrder.ToString(), Convert.ToInt32(NotificationTypes.TechnicianAssignedToOrder));
                var response = _customerService.CreatServiceOrder(model.ServiceOrder,UserId);
                return Json(response.Data.UserId);
            }            
        }
        [HttpPost]
        public IActionResult AddQuotation(CustomerViewModel model)
        {
            if (model.Quotation.Id > 0)
            {
                model.Quotation.Products = JsonConvert.DeserializeObject<List<ProductInQuotationDto>>(model.Quotation.QuotationServices);
                var UserId = _session.GetUserId();
                var response = _customerService.EditServiceOrder(model.ServiceOrder, UserId);
                return Json(1);
            }
            else
            {
                model.Quotation.Products = JsonConvert.DeserializeObject<List<ProductInQuotationDto>>(model.Quotation.QuotationServices); var UserId = _session.GetUserId();
                var response = _quotationService.AddQuotationRequestW(model.Quotation);
                return Json(1);
            }
        }
        
        public async Task<IActionResult> ServiceOrders(long? CustomerId,long? ServiceOrderId)
        {
            var vm = new CustomerViewModel();
            if (!(ServiceOrderId == null)) 
            {
                var result = _customerService.GetServiceOrderByCustomerId(CustomerId.Value, ServiceOrderId.Value);
                vm.ServiceOrder = result.Data;
                vm.ServiceCharges = vm.ServiceOrder.ServiceCharges;
                foreach (var item in result.Data.Products)
                {
                    vm.TotalCost = vm.TotalCost + item.Price;
                }
                vm.TotalPrice = vm.TotalCost + vm.ServiceCharges;
            }
            vm.ServiceOrder.CustomerId = CustomerId.Value;
            var types = await _customerTypeService.GetAllAsync();
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.CustomerTypes.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.CustomerTypes.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            var Cars = _customerService.GetAllVehiclesByCustomerId(null,CustomerId.Value);
            if (Cars.Status is 1)
                if (Cars.Data.Any())
                    vm.VehicleDropdown.AddRange(Cars.Data.Select(item => new SelectListItem { Text = item.Make + "-" + item.Model + "-" + item.Year, Value = item.Id.ToString() }));

            var services = _lookUpsService.GetLookupValueWithType("ServiceType");
            if (services.Status is 1)
                if (services.Data.Any())
                    vm.ServiceTypes.AddRange(services.Data.Select(item => new SelectListItem { Text = item.LookupTitle, Value = item.Id.ToString() }));

            var Source = _lookUpsService.GetLookupValueWithType("Source");
            if (Source.Status is 1)
                if (Source.Data.Any())
                    vm.Sources.AddRange(Source.Data.Select(item => new SelectListItem { Text = item.LookupTitle, Value = item.Id.ToString() }));

            var Agents = _userService.UsersListByRoleId(Convert.ToInt32(UserRoles.Agent));
            if (Agents.Status is 1)
                if (Agents.Data.Any())
                    vm.Agents.AddRange(Agents.Data.Select(item => new SelectListItem { Text = item.FirstName, Value = item.UserId.ToString() }));

            var Technicians = _userService.UsersListByRoleId(Convert.ToInt32(UserRoles.Technician));
            if (Technicians.Status is 1)
                if (Technicians.Data.Any())
                    vm.Technicians.AddRange(Technicians.Data.Select(item => new SelectListItem { Text = item.FirstName, Value = item.UserId.ToString() }));

            var Products = _lookUpsService.GetAllProductsList();
            if (Products.Status is 1)
                if (Products.Data.Any())
                    vm.Products.AddRange(Products.Data.Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() }));

            return View(vm);
        }

        public async Task<IActionResult> ServiceOrderList(long UserId) 
        {
            var vm = new CustomerViewModel();
            var result = await _customerService.ServicecOrderListByUserId(UserId);
            var customer = _customerService.GetCustomerByUserId(UserId);
            vm.CustomerId = customer.Id;
            vm.CustomerOrders = result;
            vm.CustomerUpdate = customer;

            return View(vm);
        }
        public async Task<IActionResult> QuotationList(long UserId)
        {
            var vm = new CustomerViewModel();
            var result = await _quotationService.GetQuotationRequestListByCustomerId(UserId);
            var customer = _customerService.GetCustomerByUserId(UserId);
            if (!(customer == null))
            {
                vm.CustomerId = customer.Id;
                vm.CustomerUpdate = customer;
            }
            else 
            {
                vm.CustomerId = 0;
                vm.CustomerUpdate = new CustomerResponseDto();
            }
            
            vm.Quotations = result.Data;
            

            return View(vm);
        }

        public async Task<IActionResult> Customers()
        {
            CustomerViewModel vm = new CustomerViewModel();
            var types = await _customerTypeService.GetAllAsync();
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.CustomerTypes.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            vm.CustomerList = _customerService.GetAllCustomer("");
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> SearchCustomers(string name)
        {
            CustomerViewModel vm = new CustomerViewModel();
            var types = await _customerTypeService.GetAllAsync();
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.CustomerTypes.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            vm.CustomerList = _customerService.GetAllCustomer(name);
            return PartialView("~/views/Customer/_CustomerListing.cshtml", vm);
        }

        public IActionResult UpdateCustomers(CustomerViewModel model)
        {
            model.CustomerList = _customerService.UpdateCustomer(model.Customer);
            return PartialView("~/views/Customer/_CustomerListing.cshtml", model);
        }

        [HttpPost]
        public IActionResult GetCustomerInfoById(long UserId) 
        {
            CustomerViewModel vm = new CustomerViewModel();
            var List = _userService.CustomerByUserId(UserId);
            vm.CustomerUpdate = List.Data;
            return Json(vm.CustomerUpdate);
        }
        
        [HttpPost]
        public async Task<IActionResult> Invoice(long CustomerId, long ServiceOrderId) 
        {
            var vm = new CustomerViewModel();
            //var result = _customerService.GetServiceOrderByCustomerId(CustomerId, ServiceOrderId);
            var InvoiceResult = await _ServiceOrderService.GetInvoiceByOrderId(ServiceOrderId);
            vm.Invoice = InvoiceResult;
            if (InvoiceResult.Products != null) 
            {
                foreach (var item in InvoiceResult.Products)
                {
                    vm.TotalCost = vm.TotalCost + item.Price;
                }
            }
            if (InvoiceResult.Services != null)
            {
                foreach (var item in InvoiceResult.Services)
                {
                    vm.ServiceCharges = vm.ServiceCharges + item.Price;
                }
            }
            vm.TotalPrice = vm.TotalCost + vm.ServiceCharges;

            return PartialView("~/views/Customer/_Invoice.cshtml", vm);
        }

        public IActionResult Vehicles(long UserId)
        {
            CustomerViewModel vm = new CustomerViewModel();
            var Customer = _customerService.GetCustomerByUserId(UserId);
            var List = _customerService.GetAllVehiclesByCustomerId(UserId,null);
            vm.VehiclesList = List.Data;
            vm.CustomerId = UserId;
            if (Customer.Id>0)
            {
                vm.CustomerName = Customer.User.FirstName + " " + Customer.User.LastName;
            }
            else 
            {
                vm.CustomerName = "Customer";
            }
            
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicles(CustomerViewModel vm)
        {
            vm.AddVehicle.UserId = vm.CustomerId;
            if (vm.AddVehicle.Id > 0)
            {
                var Vehicles = await _customerService.EditVehicle(vm.AddVehicle);
                vm.VehiclesList = Vehicles.Data;
            }
            else 
            {
                var Vehicles = _customerService.AddVehicle(vm.AddVehicle);
                vm.VehiclesList = Vehicles.Data;
            }
            return PartialView("~/views/Customer/_VehiclesList.cshtml", vm);
        }

        [HttpPost]
        public IActionResult GetVehiclesById(long Id)
        {   
            var Vehicles = _customerService.GetVehicleById(Id);
            return Json(Vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVehicles(long Id)
        {
            CustomerViewModel vm = new CustomerViewModel();
            var Vehicles = await _customerService.DeleteVehicles(Id);
            vm.VehiclesList = Vehicles.Data;
            return PartialView("~/views/Customer/_VehiclesList.cshtml", vm);
        }
        public async Task SendNotification(long TechId,string Message,int type)
        {
            Database.Dtos.NotificationDto n = new Database.Dtos.NotificationDto();
            Database.Dtos.PushQueueDto pn = new Database.Dtos.PushQueueDto();
            n.NotificationTo = TechId;
            n.NotificationFrom = _session.GetUserId();
            n.Message = Message;
            n.TypeId = type;
            await _notificationService.Create(n);

            var List = await _userService.GetUserDevices(TechId);
            foreach (var item in List.Data)
            {
                var resp = Common.SendPushNotification(item.DeviceToken, Message);
                pn.Body = resp.RequestString;
                pn.IsSent = true;
                if (resp.Status == "0") { pn.IsSent = false; }
                await _notificationService.CreatePushQueue(pn);
            }
        }

    }
}