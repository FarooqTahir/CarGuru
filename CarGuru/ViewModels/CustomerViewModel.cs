using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            CustomerTypes = new List<SelectListItem>();
            Customer = new CustomerRequestDto();
            CustomerVehicles = new List<CustomerVehicleRequestDto>();
            CustomerList = new List<UserResponseDto>();
            ServiceTypes = new List<SelectListItem>();
            Agents = new List<SelectListItem>();
            Technicians = new List<SelectListItem>();
            Products = new List<SelectListItem>();
            VehicleDropdown = new List<SelectListItem>();
            Sources = new List<SelectListItem>();
            ServiceOrder = new ServiceOrderRequestDto();
            VehiclesList = new List<CustomerVehicleResponseDto>();
            CustomerOrders = new List<ServiceOrdersListSpResponseDto>();
            Analytics = new AgentDashboardSpResponseDto();
            Quotations = new List<QuotationRequestListSpResponseDto>();
        }
        public List<SelectListItem> CustomerTypes { get; set; }
        public AgentDashboardSpResponseDto Analytics { get; set; }
        public CustomerRequestDto Customer { get; set; }
        public List<CustomerVehicleRequestDto> CustomerVehicles { get; set; }
        public string Vehicles { get; set; }
        public List<UserResponseDto> CustomerList { get; set; }
        public List<SelectListItem> ServiceTypes { get; set; }
        public List<SelectListItem> VehicleDropdown { get; set; }
        public List<SelectListItem> Sources { get; set; }
        public List<SelectListItem> Agents { get; set; }
        public List<SelectListItem> Technicians { get; set; }
        public ServiceOrderRequestDto ServiceOrder { get; set; }
        public InvoiceApiDto Invoice { get; set; }
        public List<SelectListItem> Products { get; set; }
        public string ProductsList { get; set; }
        public string ServicesList { get; set; }
        public long CustomerId { get; set; } = 0;
        public List<CustomerVehicleResponseDto> VehiclesList { get; set; }
        public CustomerResponseDto CustomerUpdate { get; set; }
        public List<ServiceOrdersListSpResponseDto> CustomerOrders { get; set; }
        public CustomerVehicleDto AddVehicle { get; set; }
        public decimal? TotalPrice { get; set; } = 0;
        public decimal? ServiceCharges { get; set; } = 0;
        public decimal? TotalCost { get; set; } = 0;
        public string CustomerName { get; set; }
        public QuotationDto Quotation { get; set; }
        public List<QuotationRequestListSpResponseDto> Quotations { get; set; }
    }
}