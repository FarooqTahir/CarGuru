using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class Vehicle
    {
        public int CustomerVehicleId { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
    }

    public class ServiceType
    {
        public string ServiceTitle { get; set; }
        public int ServiceTypeId { get; set; }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double ProductSalePrice { get; set; }
    }

    public class ServiceOrdersListUpdatedSpResponseDto
    {
        public string Agent { get; set; }
        public string Customer { get; set; }
        public string OrderStatus { get; set; }
        public string Source { get; set; }
        public string Technician { get; set; }
        public int Id { get; set; }
        public int? AgentId { get; set; }
        public int SourceId { get; set; }
        public int? AssignedToId { get; set; }
        public int OrderStatusId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public string ServiceOrderNo { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public object RatingByTechnician { get; set; }
        public object ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdateById { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<ServiceType> ServiceTypes { get; set; }
        public List<Product> Products { get; set; }
    }
}
