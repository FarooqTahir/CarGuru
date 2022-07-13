using System.Security.Principal;

namespace CarGuru.Utilities
{
    public static class Fire
    {
        public static string firebaseServerKey = "";
        public static string firebaseSenderId = "";
        
    }
    public static class ConnectionString
    {
        public static readonly string CarGuruApp = "ConnectionStrings";
    }
    public static class ResponseStrings
    {
        public static readonly string NotFound = "Not Found";
        public static readonly string Success = "Success";
        public static readonly string Unauthorized = "You are currently blocked. Please try to contact customer support.";
        public static readonly string InvalidCredentials = "Invalid username or password";
    }

    public static class SessionStrings
    {
        public static readonly string UserId = "UserId";
        public static readonly string RoleId = "RoleId";
        public static readonly string UserRoleId = "UserRoleId";
        public static readonly string TimeZoneId = "TimeZoneId";
        public static readonly string UserName = "Username";
        public static readonly string ProfilePicture = "ProfilePicture";
        public static readonly string TokenSession = "TokenSession";
        public static readonly string SessionId = "SessionId";
    }

    public enum UserRoles
    {
        Management = 1,
        Agent = 2,
        Supervisor = 3,
        Customer = 4,
        Technician = 5
    }	
    public enum NotificationTypes
    {
        TechnicianAssignedToOrder = 2016,
        NewMessage = 2017,
        QuotationRequestIsReviewed = 2018,
        OrderScheduledInMinutes = 2022,
        OrderCompletedByTechnician = 2023,
        NewOrderAssigned= 2024,
        NewQuotationRequest = 2025
    }
    public static class UserRoleStrings
    {
        public const string Management = "Management";
        public const string Agent = "Agent";
        public const string Supervisor = "Supervisor";
        public const string Customer = "Customer";
        public const string Technician = "Technician";
    }
    public static class EmailTemplatesNames
    {
        public static readonly string ForgotPassword = "ForgotPassword.txt";
    }
    public static class SourceTypes
    {
        public static readonly int Email = 2006;
        public static readonly int Call = 2007;
        public static readonly int MobileApp = 2011;
    }
    public static class OrderStatus
    {
        public static readonly int Pending = 2008;
        public static readonly int TechnicianAssigned = 2009;
        public static readonly int InProgress = 2009;
        public static readonly int Completed = 2010;
        public static readonly int CompletedByTechnician = 2015;
    }
    public static class PushNotifications
    {
        public const string QuotaionNotification = "Quotation Request Reviewd";
        public const string Agent = "Agent";
        public const string Supervisor = "Supervisor";
        public const string NewJob = "New Job Assigned";
        public const string TechAssigned = "Technician assigend to order";
        public const string NotTechAvailable = "No technician availble please contact call center";
        public const string NewMessage = "New Message Received";
    }
    public static class AdminData 
    {
        public const long Id = 3;
    }
    public static class EnviromentUrls 
    {
        public const string Local = "https://localhost:44380/";
        //public const string Url = "http://carguru.imedhealth.us/";
        public const string Url = "http://800carguru.net/";
        public const string Api = "http://carguruapi.imedhealth.us/";
    }
}
