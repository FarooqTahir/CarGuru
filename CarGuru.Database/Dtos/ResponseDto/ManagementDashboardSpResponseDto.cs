using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class TechnicianReport
    {
        public int NoOfTechnician { get; set; }
        public int UnassignedTask { get; set; }
        public int AssignedTask { get; set; }
        public int CompletedTask { get; set; }
        public int PendingTask { get; set; }
    }

    public class ProductReport
    {
        public int TotalProducts { get; set; }
        public int SoldProducts { get; set; }
        public int StockProducts { get; set; }
        public int DeadStockProducts { get; set; }
    }

    public class LeadReport
    {
        public int NoOfTechnician { get; set; }
        public int AverageLeadTime { get; set; }
        public int AverageLeadCompleted { get; set; }
    }

    public class SaleReport
    {
        public int TotalRevenue { get; set; }
        public int TotalCost { get; set; }
        public int TotatProfit { get; set; }
        public int GoalCompletion { get; set; }
    }

    public class Inventory
    {
        public int SoldProducts { get; set; }
        public int StockProducts { get; set; }
        public int DeadStockProducts { get; set; }
    }

    public class ServiceOrder
    {
        public int TotalServiceOrder { get; set; }
        public int IncompleteServiceOrder { get; set; }
        public int CompleteServiceOrder { get; set; }
    }

    public class ManagementDashboardSpResponseDto
    {
        public TechnicianReport TechnicianReport { get; set; }
        public ProductReport ProductReport { get; set; }
        public LeadReport LeadReport { get; set; }
        public SaleReport SaleReport { get; set; }
        public Leads Customers { get; set; }
        public Technicians Technicians { get; set; }
        public Inventory Inventory { get; set; }
        public ServiceOrder ServiceOrder { get; set; }
    }
}
