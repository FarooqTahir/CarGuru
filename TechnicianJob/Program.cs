using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TechnicianJob.Dtos;
using TechnicianJob.model;

namespace TechnicianJob
{
    static class Program
    {

        static void Main()
        {
            Task.Run(async () =>
            {
                using (var _db = new ApplicationDbContext())
                {
                    using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
                    {                        
                        var result = await conn.QueryAsync<AssignOrderDto>(sql: "[dbo].[spAssignTech]",
                        commandType: CommandType.StoredProcedure);
                        var FinalResult = result.FirstOrDefault();
                        var Technicians = FinalResult.AvailableTechnicians.Where(x => x.total == 0).ToList();
                        var Orders = FinalResult.Orders;

                        if (Orders.Count == Technicians.Count) 
                        {
                            foreach (var item in Orders)
                            {
                                using (var conne = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
                                {
                                    var results = await conne.QueryAsync<long>(sql: "[dbo].[spGetTechs]", param: new {
                                        ServiceOrderId=item.Id,
                                        Latitude=item.Latitude,
                                        Longitude=item.Longitude
                                    },
                                       commandType: CommandType.StoredProcedure);
                                    var techs = results.ToList();
                                    if (techs!=null && techs.Count > 0)
                                    {
                                        var TechUserDevices = await _db.UserDevices.Where(x => x.UserId == techs[0]).ToListAsync();
                                        var CustomerUserDevices = await _db.UserDevices.Where(x => x.UserId == item.CustomerUserId).ToListAsync();
                                        foreach (var d in TechUserDevices)
                                        {
                                            SendPushNotification(d.DeviceToken, "New Job Assigned");
                                        }
                                        foreach (var d in CustomerUserDevices)
                                        {
                                            SendPushNotification(d.DeviceToken, "Technician assigend to order");
                                        }
                                    }
                                    else 
                                    {
                                        SendPushNotification(item.CustomerUserId.ToString(), "No technician availble please contact call center");
                                    }                                   
                                }
                            }
                        }
                    }
                }
            }).GetAwaiter().GetResult();
        }
        public static PushResponseDto SendPushNotification(string deviceId, string message)
        {
            PushResponseDto result = new PushResponseDto();
            string applicationID = "AAAAkICGU7g:APA91bG5xP_WEYQ9RYrGZvXDIIEqW4tC5ppHtniNqKWoRuao2Yi72HHLS2SWV-bxb3gqtDZutQMiRa0pAeG-igClbzyAyd8b9WQyViek3LW9eWXmnWW1XrrHdKnDM-4ssY1Em72AdASm";
            string senderId = "620631577528";
            //string deviceId = "ch_G60NPga4:APA9............T_LH8up40Ghi-J";
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var data = new
            {
                to = deviceId,
                data = new
                {
                    msg = message,
                    title = "CarGuru",
                    type = "NOTIFICATION",
                }
            };

            var jsonString = JsonConvert.SerializeObject(data);
            Byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentLength = byteArray.Length;
            result.RequestString = jsonString;
            var response = "";

            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            string str = sResponseFromServer;
                            var jObject = JsonConvert.DeserializeObject<JObject>(str);
                            response = jObject.Value<string>("success");
                        }
                    }
                }
            }
            result.Status = response;
            return result;
        }
    }
}


