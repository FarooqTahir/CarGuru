using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class ManagementReportSpResponseDto
    {
        public ManagementReportSpResponseDto()
        {
            TechnicianData = new TechnicianData();
            ProductStat = new ProductStat();
            TechnicianData.TechnicianDetails = new List<TechnicianDetail>();
            ProductStat.ProductDetails = new List<ProductDetail>();
        }
        public TechnicianData TechnicianData { get; set; }
        public ProductStat ProductStat { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class TechnicianDetail
    {
        public string TechName { get; set; }
        public int Assigned { get; set; }
        public int Completed { get; set; }
        public int Pending { get; set; }
        public int InComplete { get; set; }
        public double Rating { get; set; }
    }

    public class TechnicianData
    {
        public int NoOfTechnician { get; set; }
        public int AssignedTask { get; set; }
        public int CompletedTask { get; set; }
        public int PendingTask { get; set; }
        public int InCompleteTask { get; set; }
        public List<TechnicianDetail> TechnicianDetails { get; set; }
    }

    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public int SoldProducts { get; set; }
    }

    public class ProductStat
    {
        public int TotalProducts { get; set; }
        public int SoldProducts { get; set; }
        public int StockProducts { get; set; }
        public int DeadStockProducts { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
