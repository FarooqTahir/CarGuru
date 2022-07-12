using Microsoft.EntityFrameworkCore;
using PushNotificationJob.model;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PushNotificationJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                using (var _db = new ApplicationDbContext())
                {
                    var list = await _db.NotificationQueue.Where(x => x.IsSent == false).ToListAsync();
                    if (!(list is null) && (list.Any()))
                    {
                        foreach (var item in list)
                        {
                            if (sendPushNotification(item.Body))
                            {
                                item.IsSent = true;
                                await _db.SaveChangesAsync();
                            }
                        }
                    }
                }
            }).GetAwaiter().GetResult();
        }
        private static bool sendPushNotification(string data)
        {
            try
            {
                string applicationID = "AAAAkICGU7g:APA91bG5xP_WEYQ9RYrGZvXDIIEqW4tC5ppHtniNqKWoRuao2Yi72HHLS2SWV-bxb3gqtDZutQMiRa0pAeG-igClbzyAyd8b9WQyViek3LW9eWXmnWW1XrrHdKnDM-4ssY1Em72AdASm";
                string senderId = "620631577528";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";

                Byte[] byteArray = Encoding.UTF8.GetBytes(data);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

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
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
