using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarGuru.Services.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private static IHostingEnvironment _hostingEnvironment;

        public CustomerService(ApplicationDbContext dbContext, IMapper mapper, IHostingEnvironment hostingEnvironment
        )
        {
            _db = dbContext;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public async Task<ResponseDto<CustomerResponseDto>> CreateAsync(CustomerRequestDto model)
        {
            if (model.UserId > 0)
            {
                var DbCustomer = _db.Customers.Where(x => x.UserId == model.UserId).FirstOrDefault();
                if (DbCustomer != null)
                {
                    DbCustomer.NoOfVehicles = model.NoOfVehicles;
                    DbCustomer.BillingAddress = model.BillingAddress;
                    DbCustomer.CustomerTypeId = model.CustomerTypeId;
                    var DbUser = _db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
                    if (DbUser != null)
                    {
                        DbUser.FirstName = model.User.FirstName;
                        DbUser.LastName = model.User.LastName;
                        DbUser.Email = model.User.Email;
                        DbUser.Address = model.User.Address;
                        DbUser.PhoneNumber = model.User.PhoneNumber;
                        DbUser.Password = model.User.Password;
                        DbUser.UpdatedDate = DateTime.UtcNow;
                        if(!string.IsNullOrEmpty(model.ProfileUrl)) DbUser.ProfileUrl = model.ProfileUrl;
                    }
                    await _db.SaveChangesAsync();
                    var Response = _mapper.Map<Customers, CustomerResponseDto>(DbCustomer);
                    return new ResponseDto<CustomerResponseDto>() { Data = Response };
                }
                else 
                {
                    var DbUser = _db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
                    if (DbUser != null)
                    {
                        DbUser.FirstName = model.User.FirstName;
                        DbUser.LastName = model.User.LastName;
                        DbUser.Email = model.User.Email;
                        DbUser.Address = model.User.Address;
                        DbUser.PhoneNumber = model.User.PhoneNumber;
                        DbUser.Password = model.User.Password;
                        DbUser.UpdatedDate = DateTime.UtcNow;
                        if (!string.IsNullOrEmpty(model.ProfileUrl)) DbUser.ProfileUrl = model.ProfileUrl;
                    }
                    var mappedObject = _mapper.Map<CustomerRequestDto, Customers>(model);
                    mappedObject.User = DbUser; 
                    mappedObject.User.CreatedDate = DateTime.UtcNow;
                    mappedObject.User.RoleId = Convert.ToInt32(UserRoles.Customer);
                    //_db.Customers.Add(mappedObject);
                    await _db.SaveChangesAsync();
                    var mappedResponse = _mapper.Map<Customers, CustomerResponseDto>(mappedObject);
                    return new ResponseDto<CustomerResponseDto>() { Data = mappedResponse };
                }
            }
            else 
            {
                var mappedObject = _mapper.Map<CustomerRequestDto, Customers>(model);
                mappedObject.User.CreatedDate = DateTime.UtcNow;
                mappedObject.User.CreatedById = 3;
                _db.Customers.Add(mappedObject);
                await _db.SaveChangesAsync();
                var mappedResponse = _mapper.Map<Customers, CustomerResponseDto>(mappedObject);
                return new ResponseDto<CustomerResponseDto>() { Data = mappedResponse };
            }
            
        }
        public async Task<ResponseDto<CustomerResponseDto>> EditCustomerAsync(EditCustomerRequestDto model)
        {
            if (model.UserId > 0)
            {
                var DbCustomer = _db.Customers.Where(x => x.UserId == model.UserId).FirstOrDefault();
                if (DbCustomer != null)
                {
                    //DbCustomer.NoOfVehicles = model.NoOfVehicles;
                    //DbCustomer.BillingAddress = model.BillingAddress;
                    //DbCustomer.CustomerTypeId = model.CustomerTypeId;
                    var DbUser = _db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
                    if (DbUser != null)
                    {
                        DbUser.FirstName = model.FirstName;
                        DbUser.LastName = model.LastName;
                        DbUser.Email = model.Email;
                        DbUser.Address = model.Address;
                        DbUser.PhoneNumber = model.PhoneNumber;
                        //DbUser.Password = model.User.Password;
                        DbUser.UpdatedDate = DateTime.UtcNow;
                        if (!string.IsNullOrEmpty(model.ProfileUrl)) DbUser.ProfileUrl = model.ProfileUrl;
                    }
                    await _db.SaveChangesAsync();
                    var Response = _mapper.Map<Customers, CustomerResponseDto>(DbCustomer);
                    return new ResponseDto<CustomerResponseDto>() { Data = Response };
                }
                else
                {
                    var DbUser = _db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
                    if (DbUser != null)
                    {
                        DbUser.FirstName = model.FirstName;
                        DbUser.LastName = model.LastName;
                        DbUser.Email = model.Email;
                        DbUser.Address = model.Address;
                        DbUser.PhoneNumber = model.PhoneNumber;
                        //DbUser.Password = model.User.Password;
                        DbUser.UpdatedDate = DateTime.UtcNow;
                        if (!string.IsNullOrEmpty(model.ProfileUrl)) DbUser.ProfileUrl = model.ProfileUrl;
                    }
                    var mappedObject = _mapper.Map<EditCustomerRequestDto, Customers>(model);
                    mappedObject.User = DbUser;
                    mappedObject.User.CreatedDate = DateTime.UtcNow;
                    mappedObject.User.RoleId = Convert.ToInt32(UserRoles.Customer);
                    //_db.Customers.Add(mappedObject);
                    await _db.SaveChangesAsync();
                    var mappedResponse = _mapper.Map<Customers, CustomerResponseDto>(mappedObject);
                    return new ResponseDto<CustomerResponseDto>() { Data = mappedResponse };
                }
            }
            else
            {
                var mappedObject = _mapper.Map<EditCustomerRequestDto, Customers>(model);
                mappedObject.User.CreatedDate = DateTime.UtcNow;
                mappedObject.User.CreatedById = 3;
                _db.Customers.Add(mappedObject);
                await _db.SaveChangesAsync();
                var mappedResponse = _mapper.Map<Customers, CustomerResponseDto>(mappedObject);
                return new ResponseDto<CustomerResponseDto>() { Data = mappedResponse };
            }

        }
        public List<UserResponseDto> UpdateCustomer(CustomerRequestDto model)
        {
            var DbCustomer = _db.Customers.Where(x => x.UserId == model.UserId).FirstOrDefault();
            
                DbCustomer.NoOfVehicles = model.NoOfVehicles;
                DbCustomer.BillingAddress = model.BillingAddress;
                DbCustomer.CustomerTypeId = model.CustomerTypeId;
                var DbUser = _db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
                if (DbUser != null)
                {
                    DbUser.RoleId = Convert.ToInt32(UserRoles.Customer);
                    DbUser.FirstName = model.User.FirstName;
                    DbUser.LastName = model.User.LastName;
                    DbUser.Email = model.User.Email;
                    DbUser.Address = model.User.Address;
                    DbUser.PhoneNumber = model.User.PhoneNumber;
                    DbUser.GenderId = model.User.GenderId;
                    DbUser.Password = model.User.Password;
                    DbUser.UpdatedDate = DateTime.UtcNow;
                }
                _db.Entry(DbCustomer).State = EntityState.Modified;
                _db.Entry(DbUser).State = EntityState.Modified;
                _db.SaveChanges();

            var Users = _db.Users.Where(x => x.RoleId == Convert.ToInt32(UserRoles.Customer) && x.IsActive==true).OrderByDescending(x => x.UserId).ToList();
            var List = _mapper.Map<List<Users>, List<UserResponseDto>>(Users);
            return List;

        }
        public async Task<ResponseDto<CustomerResponseDto>> CreateWithVehicles(CustomerRequestDto model, List<CustomerVehicleRequestDto> Vehicles,long CreatedBy)
        {
            var mappedObject = _mapper.Map<CustomerRequestDto, Customers>(model);
            mappedObject.User.CreatedDate=DateTime.UtcNow;
            mappedObject.CustomerVehicles = new List<CustomerVehicles>();
            mappedObject.User.Password = Common.RandomPassword(8);
            SendPassword(mappedObject.User.Email, mappedObject.User.Password);
            Vehicles = Vehicles.GroupBy(x => x.Id).Select(x => x.First()).ToList();
            var MappedVehicles = _mapper.Map<List<CustomerVehicleRequestDto>, List<CustomerVehicles>>(Vehicles);
            mappedObject.CustomerVehicles = MappedVehicles;
            var Customer = _db.Customers.Add(mappedObject);
            await _db.SaveChangesAsync();

            var mappedResponse = _mapper.Map<Customers, CustomerResponseDto>(mappedObject);
            return new ResponseDto<CustomerResponseDto>() { Data = mappedResponse };
        }
        public void SendPassword(string Email, string password)
        {
            string emailTemplateBody;
            var env = _hostingEnvironment.WebRootPath + "\\EmailTemplates\\ForgotPassword.txt";
            emailTemplateBody = File.ReadAllText(env);
            string messageBody = string.Format(emailTemplateBody,
                password
            );
            EmailDto Mail = new EmailDto()
            {
                Body = messageBody,
                Subject = "Password Changed Successfully",
            };
            Mail.ToEmails.Add(Email);
            EmailSender.SendEmailAsync(Mail);
        }
        public List<UserResponseDto> GetAllCustomer(string name) 
        {
            if (name == ""||name==null)
            {
                var Users = _db.Users.Where(x => x.RoleId == Convert.ToInt32(UserRoles.Customer)).ToList();
                var List = _mapper.Map<List<Users>, List<UserResponseDto>>(Users);
                List = List.OrderByDescending(x => x.UserId).ToList();
                return List;
            }
            else 
            {
                var Users= from User in _db.Users
                           where User.FirstName.Contains(name) || User.LastName.Contains(name)|| (User.FirstName+" "+User.LastName).Contains(name)
                           select User;
                var List = _mapper.Map<List<Users>, List<UserResponseDto>>(Users.ToList());
                List = List.OrderByDescending(x => x.UserId).ToList();
                return List;
            }
        }
        public ResponseDto<CustomerResponseDto> CreatServiceOrder(ServiceOrderRequestDto model,long CreatedBy) 
        {
            model.Products = model.Products.Where(a => a.ProductId != 0).GroupBy(x => x.ProductId).Select(x => x.First()).ToList();
            model.Services = model.Services.Where(a => a.ServiceTypeId != 0).GroupBy(x => x.ServiceTypeId).Select(x => x.First()).ToList();

            var mappedObject = _mapper.Map<ServiceOrderRequestDto, ServiceOrders>(model);
            var mappedProduct = _mapper.Map<List<ProductInServiceOrderDto>, List<ProductsInServiceOrders>>(model.Products);
            var mappedServices = _mapper.Map<List<ServicesInServiceOrderDto>, List<ServicesInOrder>>(model.Services);
            string ProductIds = string.Join(",", mappedProduct.Select(x => x.ProductId));   
            var CustomerUser = _db.Customers.Where(x => x.Id == mappedObject.CustomerId).FirstOrDefault();
            if (CustomerUser != null)
            {
                var UserDevices = _db.UserDevices.Where(a => a.UserId == CustomerUser.UserId).ToList();
                if (UserDevices != null)
                {
                    foreach (var item in UserDevices)
                    {
                        Common.SendPushNotification(item.DeviceToken, PushNotifications.TechAssigned);
                    }
                }
            }
            Notifications n = new Notifications();
            n.NotificationTo = CustomerUser.UserId;
            n.NotificationFrom = AdminData.Id;
            n.CreatedDate = DateTime.UtcNow;
            n.Message = "Technician Assigned To Order";
            n.TypeId = Convert.ToInt32(NotificationTypes.TechnicianAssignedToOrder);
            _db.Notifications.Add(n);
            mappedObject.ServiceOrderNo = Common.RandomNumber(99999, 1000000).ToString();
            mappedObject.CreatedDate = DateTime.UtcNow;
            mappedObject.CreatedById = CreatedBy;

            if (mappedObject.AssignedToId != null && mappedObject.AssignedToId > 0)
            {
                mappedObject.OrderStatusId = OrderStatus.TechnicianAssigned;
            }
            else 
            {
                mappedObject.OrderStatusId = OrderStatus.Pending;
            }
            var ServiceOrders = _db.ServiceOrders.Add(mappedObject);
            _db.SaveChanges();

            if (ProductIds.Length > 0)
            {
                using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
                {
                    var result = conn.Query<Products>(sql: "[dbo].[spMaintainStock]", param: new { List = ProductIds },
                       commandType: CommandType.StoredProcedure);
                    var response = result.ToList().OrderBy(x => x.CreatedDate).ToList();
                    Notifications noti = new Notifications();
                    foreach (var item in response)
                    {
                        var Notification = new Notifications()
                        {
                            NotificationTo = AdminData.Id,
                            NotificationFrom = model.CustomerId,
                            Message = item.Name + "has reached its dead stock",
                            TypeId = Convert.ToInt32(NotificationTypes.NewQuotationRequest)
                        };
                        _db.Notifications.Add(Notification);
                    }       
                }
            }

            foreach (var item in mappedServices)
            {
                item.ServiceOrderId = mappedObject.Id;
                _db.ServicesInOrder.Add(item);
            }
            foreach (var item in mappedProduct)
            {
                item.ServiceOrderId = mappedObject.Id;
                _db.ProductsInServiceOrders.Add(item);
            }
            _db.SaveChanges();
            var Customer = _db.Customers.Where(x => x.Id == model.CustomerId).FirstOrDefault();
            var Object = _mapper.Map<Customers, CustomerResponseDto>(Customer);

            return new ResponseDto<CustomerResponseDto>() { Data = Object };
        }
        public ResponseDto<CustomerResponseDto> EditServiceOrder(ServiceOrderRequestDto model,long UpdatedBy)
        {
            var mappedObject = _mapper.Map<ServiceOrderRequestDto, ServiceOrders>(model);
            foreach (var item in model.Services)
            {
                item.ServiceOrderId = mappedObject.Id;
            }
            var toDelProducts = _db.ProductsInServiceOrders.Where(x => x.ServiceOrderId == mappedObject.Id).ToList();
            var toDelServices = _db.ServicesInOrder.Where(x => x.ServiceOrderId == mappedObject.Id).ToList();
            foreach (var item in toDelProducts)
            {
                _db.ProductsInServiceOrders.Remove(item);
            }
            foreach (var item in toDelServices)
            {
                _db.ServicesInOrder.Remove(item);
            }
            _db.SaveChanges();
            mappedObject.AgentId = model.AgentId;
            mappedObject.AssignedToId = model.AssignedToId;
            mappedObject.VehicleId = model.VehicleId;
            mappedObject.OrderStatusId = OrderStatus.TechnicianAssigned;
            mappedObject.SourceId = model.SourceId;
            mappedObject.UpdatedDate = DateTime.UtcNow;
            mappedObject.UpdateById = UpdatedBy;

            var mappedProduct = _mapper.Map<List<ProductInServiceOrderDto>, List<ProductsInServiceOrders>>(model.Products);
            var mappedServices = _mapper.Map<List<ServicesInServiceOrderDto>, List<ServicesInOrder>>(model.Services);
            mappedProduct = mappedProduct.GroupBy(a => a.ProductId).Select(g => g.First()).Where(a=>a.ProductId!=0).ToList();
            mappedServices = mappedServices.GroupBy(a => a.ServiceTypeId).Select(g => g.First()).Where(a => a.ServiceTypeId != 0).ToList();
            foreach (var item in mappedProduct)
            {
                item.ServiceOrderId = mappedObject.Id;
            }
            foreach (var item in mappedServices)
            {
                item.ServiceOrderId = mappedObject.Id;
            }
            _db.ProductsInServiceOrders.AddRange(mappedProduct);
            _db.ServicesInOrder.AddRange(mappedServices);
            _db.Entry(mappedObject).State = EntityState.Modified;
            _db.SaveChanges();
            var Customer = _db.Customers.Where(x => x.Id == model.CustomerId).FirstOrDefault();
            var Object = _mapper.Map<Customers, CustomerResponseDto>(Customer);

            return new ResponseDto<CustomerResponseDto>() { Data = Object };

        }
        public ResponseDto<ServiceOrderRequestDto> GetServiceOrderByCustomerId(long Id,long serviceOrderId)
        {
            ServiceOrderRequestDto Result = new ServiceOrderRequestDto();
            var model = _db.ServiceOrders.FirstOrDefault(x => x.CustomerId == Id && x.Id == serviceOrderId);
            if (!(model == null))
            {
                Result = _mapper.Map<ServiceOrders, ServiceOrderRequestDto>(model);
                var products = _db.ProductsInServiceOrders.Where(x => x.ServiceOrderId == Result.Id).ToList();
                if (!(products == null) && products.Count > 0) 
                {
                    var mappedProduct = _mapper.Map<List<ProductsInServiceOrders>, List<ProductInServiceOrderDto>>(products);
                    foreach (var item in mappedProduct)
                    {
                        var Product = _db.Products.Where(x => x.Id == item.ProductId).FirstOrDefault();
                        item.Name = Product.Name;
                    }
                    Result.Products = mappedProduct;

                }
                var Services = _db.ServicesInOrder.Where(x => x.ServiceOrderId == Result.Id).ToList();
                if (!(Services == null) && Services.Count > 0)
                {
                    var mappedServices = _mapper.Map<List<ServicesInOrder>, List<ServicesInServiceOrderDto>>(Services);
                    foreach (var item in mappedServices)
                    {
                        //var dbService = _db.Lookups.Where(x => x.Id == item.ServiceTypeId).FirstOrDefault();
                        var dbService = _db.ServiceType.FirstOrDefault(x => x.Id == item.ServiceTypeId);
                        if(!(dbService is null))
                        item.Name = dbService.Title;
                    }
                    Result.Services = mappedServices;
                }
            }
            return new ResponseDto<ServiceOrderRequestDto>() { Data = Result };
        }
        public ResponseDto<ServiceOrderRequestDto> GetServiceOrderByCustomerIdM(long Id, long serviceOrderId)
        {
            ServiceOrderRequestDto Result = new ServiceOrderRequestDto();
            var customer = _db.Customers.Where(x => x.UserId == Id).FirstOrDefault();
            var model = _db.ServiceOrders.Where(x => x.CustomerId == customer.Id && x.Id == serviceOrderId && x.OrderStatusId == OrderStatus.CompletedByTechnician).FirstOrDefault();
            if (!(model == null))
            {
                Result = _mapper.Map<ServiceOrders, ServiceOrderRequestDto>(model);
                var products = _db.ProductsInServiceOrders.Where(x => x.ServiceOrderId == Result.Id).ToList();
                if (!(products == null))
                {
                    var mappedProduct = _mapper.Map<List<ProductsInServiceOrders>, List<ProductInServiceOrderDto>>(products);
                    foreach (var item in mappedProduct)
                    {
                        var Product = _db.Products.Where(x => x.Id == item.ProductId).FirstOrDefault();
                        item.Name = Product.Name;
                    }
                    Result.Products = mappedProduct;

                }
                var Services = _db.ServicesInOrder.Where(x => x.ServiceOrderId == Result.Id).ToList();
                if (!(Services == null))
                {
                    var mappedServices = _mapper.Map<List<ServicesInOrder>, List<ServicesInServiceOrderDto>>(Services);
                    foreach (var item in mappedServices)
                    {
                        var dbService = _db.Lookups.Where(x => x.Id == item.ServiceTypeId).FirstOrDefault();
                        item.Name = dbService.LookupValue;
                    }
                    Result.Services = mappedServices;
                }
            }
            return new ResponseDto<ServiceOrderRequestDto>() { Data = Result };
        }
        public ResponseDto<List<CustomerVehicleResponseDto>> GetAllVehiclesByCustomerId(long? UserId,long? CustomerId)
        {
            if (!(CustomerId == null)) 
            {
                var Cars = _db.CustomerVehicles.Where(x => x.CustomerId == CustomerId && x.IsActive == true).ToList();
                var mappedCars = _mapper.Map<List<CustomerVehicles>, List<CustomerVehicleResponseDto>>(Cars);
                return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = mappedCars };
            }
            var DbCustomer = _db.Customers.Where(x => x.UserId == UserId).FirstOrDefault();
            if (!(DbCustomer == null)) 
            {
                var Vehicles = _db.CustomerVehicles.Where(x => x.CustomerId == DbCustomer.Id && x.IsActive == true).ToList();
                var mappedResponse = _mapper.Map<List<CustomerVehicles>, List<CustomerVehicleResponseDto>>(Vehicles);
                return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = mappedResponse };
            }
            return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = null };
        }
        public async Task<ResponseDto<List<CustomerVehicleResponseDto>>> DeleteAsync(long vendorId)
        {
            var vehicle = await _db.CustomerVehicles.FirstOrDefaultAsync(v => v.Id == vendorId);
            if (!(vehicle is null))
            {
                vehicle.IsActive = false;
                _db.Entry(vehicle).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            var dbObject = await _db.Vendors.Where(a => a.IsActive.Value).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<CustomerVehicleResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<CustomerVehicleResponseDto>>(dbObject);
            return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = mappedObject };
        }
        public ResponseDto<List<CustomerVehicleResponseDto>> AddVehicle(CustomerVehicleDto model)
        {
            var customer = _db.Customers.Where(x => x.UserId == model.UserId).FirstOrDefault();
            var MappedVehicle = _mapper.Map<CustomerVehicleDto, CustomerVehicles>(model);
            MappedVehicle.CreatedDate = DateTime.UtcNow;
            MappedVehicle.IsActive = true;
            MappedVehicle.CustomerId = customer.Id;
            _db.CustomerVehicles.Add(MappedVehicle);
            _db.SaveChanges();
            var vehiclesList = _db.CustomerVehicles.Where(a => a.CustomerId == customer.Id && a.IsActive==true).ToList();
            var mappedResponse = _mapper.Map<List<CustomerVehicles>,List<CustomerVehicleResponseDto>>(vehiclesList);
            if (mappedResponse is null) return new ResponseDto<List<CustomerVehicleResponseDto>>() { Status = 0, Data = null };
            return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = mappedResponse };
        }
        public async Task<ResponseDto<List<CustomerVehicleResponseDto>>> EditVehicle(CustomerVehicleDto model)
        {
            var vehicle = await _db.CustomerVehicles.FirstOrDefaultAsync(v => v.Id == model.Id);
            if (!(vehicle is null))
            {
                vehicle.LicensePlateNumber = model.LicensePlateNumber;
                vehicle.Make = model.Make;
                vehicle.Model = model.Model;
                vehicle.VIN = model.VIN;
                vehicle.Year = model.Year;
                vehicle.Mulkia = model.Mulkia;
                vehicle.UpdatedDate = DateTime.UtcNow;
                _db.Entry(vehicle).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            var vehiclesList = _db.CustomerVehicles.Where(a => a.CustomerId == vehicle.CustomerId && a.IsActive == true).ToList();
            var mappedResponse = _mapper.Map<List<CustomerVehicles>, List<CustomerVehicleResponseDto>>(vehiclesList);
            if (mappedResponse is null) return new ResponseDto<List<CustomerVehicleResponseDto>>() { Status = 0, Data = null };
            return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = mappedResponse };
        }
        public async Task<ResponseDto<List<CustomerVehicleResponseDto>>> DeleteVehicles(long Id)
        {
            var vehicle = await _db.CustomerVehicles.FirstOrDefaultAsync(v => v.Id == Id);
            if (!(vehicle is null))
            {
                vehicle.IsActive = false;
                vehicle.UpdatedDate = DateTime.UtcNow;
                _db.Entry(vehicle).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            var vehiclesList = _db.CustomerVehicles.Where(a => a.CustomerId == vehicle.CustomerId && a.IsActive == true).ToList();
            var mappedResponse = _mapper.Map<List<CustomerVehicles>, List<CustomerVehicleResponseDto>>(vehiclesList);
            if (mappedResponse is null) return new ResponseDto<List<CustomerVehicleResponseDto>>() { Status = 0, Data = null };
            return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = mappedResponse };
        }
        public async Task<ResponseDto<List<CustomerVehicleResponseDto>>> GetVehicleByUserId(long id)
        {
            var customer = _db.Customers.FirstOrDefault(v => v.UserId == id);
           
            var dbObject = await _db.CustomerVehicles.Where(a => a.IsActive ==true && a.CustomerId== customer.Id).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<CustomerVehicleResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<CustomerVehicleResponseDto>>(dbObject);
            return new ResponseDto<List<CustomerVehicleResponseDto>>() { Data = mappedObject };
        }
        public ResponseDto<CustomerVehicleResponseDto> GetVehicleById(long id)
        {
            var customer = _db.Customers.FirstOrDefault(v => v.UserId == id);

            var dbObject = _db.CustomerVehicles.Where(a => a.IsActive == true && a.Id == id).FirstOrDefault();
            if (dbObject is null) return new ResponseDto<CustomerVehicleResponseDto>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<CustomerVehicleResponseDto>(dbObject);
            return new ResponseDto<CustomerVehicleResponseDto>() { Data = mappedObject };
        }
        public async Task<List<ServiceOrdersListSpResponseDto>> ServicecOrderListByUserId(long UserId)
        {
            var customer = _db.Customers.Where(x => x.UserId == UserId).FirstOrDefault();
            if (customer != null) 
            {
                using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<ServiceOrdersListSpResponseDto>(sql: "[dbo].[GetServiceOrdersByCustomerId]", param: new { CustomerId = customer.Id },
                       commandType: CommandType.StoredProcedure);
                    var response = result.ToList().OrderBy(x => x.CreatedDate).ToList();
                    if (!(response is null))
                    {
                        return response;
                    }
                    return new List<ServiceOrdersListSpResponseDto>();
                }
            }
               return new List<ServiceOrdersListSpResponseDto>();
            
        }
        public async Task<List<ServiceOrdersListUpdatedSpResponseDto>> ServicecOrderListByUserIdUpdated(long UserId)
        {
            var customer = _db.Customers.Where(x => x.UserId == UserId).FirstOrDefault();
            if (customer != null)
            {
                using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<string>(sql: "[dbo].[GetServiceOrdersByCustomerIdUpdated]", param: new { CustomerId = customer.Id },
                       commandType: CommandType.StoredProcedure);
                    StringBuilder builder = new StringBuilder();
                    foreach (var r in result)
                    {
                        builder.Append(r);
                    }
                    var response = JsonConvert.DeserializeObject<List<ServiceOrdersListUpdatedSpResponseDto>>(builder.ToString());
                    if (!(response is null))
                    {
                        return response;
                    }
                    return new List<ServiceOrdersListUpdatedSpResponseDto>();
                }
            }
            return new List<ServiceOrdersListUpdatedSpResponseDto>();

        }
        public async Task<List<ServiceOrdersListSpResponseDto>> InvoiceListByUserId(long UserId)
        {
            var customer = _db.Customers.Where(x => x.UserId == UserId).FirstOrDefault();
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ServiceOrdersListSpResponseDto>(sql: "[dbo].[GetServiceOrdersByCustomerId]", param: new { CustomerId = customer.Id },
                   commandType: CommandType.StoredProcedure);
                var response = result.ToList().Where(x=>x.OrderStatusId == OrderStatus.Completed).OrderBy(x => x.CreatedDate).ToList();
                if (!(response is null))
                {
                    return response;
                }
                return new List<ServiceOrdersListSpResponseDto>();
            }
        }
        public async Task<List<ServiceOrdersListSpResponseDto>> ServicecOrderListByTechId(long UserId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[dbo].[GetServiceOrdersByCustomerIdUpdated]",
                   commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<List<ServiceOrdersListSpResponseDto>>(builder.ToString());
                 response = response.Where(x=>x.AssignedToId==UserId).ToList();
                if (!(response is null))
                {
                    return response;
                }
                return new List<ServiceOrdersListSpResponseDto>();
            }
        }
        public async Task<List<ServiceOrdersListSpResponseDto>> GetAllServicecOrderList()
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ServiceOrdersListSpResponseDto>(sql: "[dbo].[GetServiceOrdersByCustomerId]",
                   commandType: CommandType.StoredProcedure);
                var response = result.ToList().OrderBy(x => x.CreatedDate).ToList();
                if (!(response is null))
                {
                    return response;
                }
                return new List<ServiceOrdersListSpResponseDto>();
            }
        }
        public CustomerResponseDto GetCustomerByUserId(long UserId) 
        {
            var customer = _db.Customers.Where(x => x.UserId == UserId).FirstOrDefault();
            if (!(customer==null)) 
            {
                customer.User = _db.Users.Where(x => x.UserId == UserId).FirstOrDefault();
                var mappedResponse = _mapper.Map<Customers, CustomerResponseDto>(customer);
                return mappedResponse;
            }
            return new CustomerResponseDto();
        }
        public async Task<ResponseDto<ServiceOrderApiDto>> AddServiceOrderM(ServiceOrderApiDto model)
        {
            long customerId = _db.Customers.Where(x => x.UserId == model.CustomerId).FirstOrDefault().Id;

            var mappedObject = _mapper.Map<ServiceOrderApiDto, ServiceOrders>(model);
            model.Services = model.Services.GroupBy(x => x.ServiceTypeId).Select(x => x.First()).ToList();
            var mappedServices = _mapper.Map<List<MServices>, List<ServicesInOrder>>(model.Services);
            mappedObject.ScheduleDateTime = model.SchaduleDateTime;
            mappedObject.CustomerId = customerId;
            mappedObject.SourceId = SourceTypes.MobileApp;
            mappedObject.OrderStatusId = OrderStatus.Pending;
            mappedObject.ServiceOrderNo = Common.RandomNumber(99999, 1000000).ToString();
            mappedObject.CreatedDate = DateTime.UtcNow;
            mappedObject.TotalPrice = 0;
            mappedObject.ReceivedDate = DateTime.UtcNow;
            mappedObject.CreatedById = AdminData.Id;//Admin user id
            _db.ServiceOrders.Add(mappedObject);
            var ServiceOrders = _db.SaveChanges();
            foreach (var item in mappedServices)
            {
                item.ServiceOrderId = mappedObject.Id;
                _db.ServicesInOrder.Add(item);
            }
            using (var conne = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var data = _db.Database.GetDbConnection().ConnectionString;
                var Lat = Convert.ToDouble(mappedObject.Latitude);
                var Lon = Convert.ToDouble(mappedObject.Longitude);
                var results = await conne.QueryAsync<long>(sql: "[dbo].[spGetTechs]", param: new
                {
                    ServiceOrderId = mappedObject.Id,
                    Latitude = Lat,
                    Longitude = Lon
                },
                   commandType: CommandType.StoredProcedure);
                var techs = results.ToList();
                var CustomerUserDevices = await _db.UserDevices.Where(x => x.UserId == model.CustomerId).ToListAsync();
                if (techs != null && techs.Count > 0)
                {
                    var TechUserDevices = await _db.UserDevices.Where(x => x.UserId == techs[0]).ToListAsync();
                    
                    foreach (var d in TechUserDevices)
                    {
                        Common.SendPushNotification(d.DeviceToken, PushNotifications.NewJob);
                    }
                    foreach (var d in CustomerUserDevices)
                    {                        
                        Common.SendPushNotification(d.DeviceToken, PushNotifications.TechAssigned);
                    }
                }
                else
                {
                    foreach (var d in CustomerUserDevices)
                    {
                        Common.SendPushNotification(d.DeviceToken, PushNotifications.NotTechAvailable);
                    }
                }
            }
            var Status = await _db.SaveChangesAsync();
            if (Status > 0)
            {
                return new ResponseDto<ServiceOrderApiDto>() { Data = model, Message = "Success", Status = 1 };
            }
            return new ResponseDto<ServiceOrderApiDto>() { Data = null, Message = "Something went wrong", Status = 0 };

        }
        public List<long> ServicecOrderListDropdownByUserId(long UserId)
        {
            var customer = _db.Customers.Where(x => x.UserId == UserId).FirstOrDefault();
            var result = _db.ServiceOrders.Where(x => x.CustomerId == customer.Id && x.AssignedToId!=null).ToList();
            var response = result.ToList().OrderBy(x => x.CreatedDate).ToList();
                List<long> Ids = new List<long>();
                foreach (var item in response)
                {
                    Ids.Add(Convert.ToInt64(item.ServiceOrderNo));
                }
                if (!(response is null))
                {
                    return Ids;
                }
                return new List<long>();
        }
    }
}