using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Nancy.Json;
using NWebsec.AspNetCore.Core.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Http.Controllers;

namespace CarGuru.Filters
{
    public class HandleLogs
    {

        public HandleLogs()
        {
                
        }
        public static void Write(long userId,ActionExecutedContext actionContext)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            string requestedController = (string)actionContext.RouteData.Values["Controller"];
            string requestedAction = (string)actionContext.RouteData.Values["Action"];
            //string action = actionContext.ActionDescriptor.DisplayName;
            //string controller = actionContext.Controller.GetType().Name;
            //string requestedController = actionContext.ActionDescriptor.
            //string requestedAction = actionContext.ActionDescriptor.;
            dynamic requestData = actionContext.HttpContext.Request.Body;
            dynamic request = requestData.Value;
            dynamic responseData = actionContext.HttpContext.Response.Body;
            dynamic v = responseData.Value;

            try
            {

                //APILogsRepo apiLogsRepo = new APILogsRepo();
                //APILog logs = new APILog()
                //{
                //    UserId = userId,
                //    ActionName = requestedAction,
                //    ControllerName = requestedController,
                //    FunctionRequest = javaScriptSerializer.Serialize(request),
                //    //FunctionRequest = Security.Encrypt(request, SecurityKey.PasswordKey),
                //    FunctionResponse = javaScriptSerializer.Serialize(v),
                //    IPAddress = "",
                //    CreatedDate = DateTime.UtcNow
                //};

                //apiLogsRepo.AddAPILogs(logs);
            }
            catch (Exception)
            {


            }
        }
    }
}
