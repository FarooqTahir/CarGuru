using System;
using System.Collections.Generic;
using System.Text;

namespace CarGuru.Database.Dtos.ResponseDto
{
    public class AgentDashboardSpResponseDto
    {
        public Leads Leads { get; set; }
        public Technicians Technicians { get; set; }
        public ServiceOrder ServiceOrder { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Leads
    {
        public int NewLeads { get; set; }
        public int ServiceRequest { get; set; }
        public int QuotationRequest { get; set; }
    }
    public class Technicians
    {
        public int CompleteJobs { get; set; }
        public int LateJob { get; set; }
        public int JobFailed { get; set; }
    }
    
}
