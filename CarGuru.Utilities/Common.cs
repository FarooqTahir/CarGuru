using CarGuru.Database.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CarGuru.Utilities
{
    public static class Common
    {
        public static string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static PushResponseDto SendPushNotification(string deviceId, string message)
        {

                string applicationID = Fire.firebaseServerKey;
                string senderId = Fire.firebaseSenderId;

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var json = "";
                var payload = new
                {
                    to = deviceId,
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = message,
                        title = "Car Guru",
                        badge = 1,
                        type = "Notification"
                    },
                    data = new
                    {
                        body = message,
                        title = PushNotifications.QuotaionNotification
                    }

                };
                json = JsonConvert.SerializeObject(payload).ToString();
                //if (type.Equals("1"))
                //{
                    
                    
                //}
                //else
                //{
                //    var payload = new
                //    {
                //        to = deviceId,
                //        priority = "high",
                //        content_available = true,
                        
                //    };
                //    json = JsonConvert.SerializeObject(payload).ToString();
                //}

                
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                string str = "";
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
                                str = sResponseFromServer;
                            }
                        }
                    }
                }
            return new PushResponseDto() {RequestString = json,Status = str };            
        }

    }
}