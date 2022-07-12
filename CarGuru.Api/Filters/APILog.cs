using CarGuru.Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Nancy.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CarGuru.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class APILog : ActionFilterAttribute,IActionFilter,IFilterFactory
    {
        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    // our code before action executes
        //}
        private IHangleLog _log;
        public APILog(IHangleLog log)
        {
            _log = log;
        }

        public bool IsReusable => throw new NotImplementedException();

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            // gets the dependecies from the serviceProvider 
            // and creates an instance of the filter
            return new APILog(
                (IHangleLog)serviceProvider.GetService(typeof(IHangleLog)));
        }
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            long LogId =  _log.Add(context);
            context.HttpContext.Request.Headers.Add("LogId",Convert.ToString(LogId));
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            long LogId = GetLogId(actionExecutedContext);
            string response = "";
            if (actionExecutedContext.Result is ObjectResult)
            {
                var objResult = (ObjectResult)actionExecutedContext.Result;
                response = javaScriptSerializer.Serialize(objResult.Value);
            }
            //var d = actionExecutedContext.ActionContext;
            //var data1 = actionExecutedContext.Result;
            //var _log = actionExecutedContext.HttpContext.RequestServices.GetService<IHangleLog>();
            //int UserId = Convert.ToInt32(actionExecutedContext.HttpContext.Request.Headers.Properties["UserId"]);
            //var bodyStr = "";
            //var req = actionExecutedContext.HttpContext.Response;

            // Allows using several time the stream in ASP.Net Core
            //req.EnableBuffering();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            //using (StreamReader reader
            //          = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            //{
            //   var bodStr = reader.ReadToEndAsync();
            //}

            // Rewind, so the core is not lost when it looks the body for the request
            //req.Body.Position = 0;

            //actionExecutedContext.HttpContext.Request.EnableBuffering();
            //if (actionExecutedContext.HttpContext.Request.Method == "POST")
            //{
            //    actionExecutedContext.HttpContext.Request.EnableBuffering();
            //    var body =  new StreamReader(actionExecutedContext.HttpContext.Request.Body)
            //                                        .ReadToEndAsync();
            //    actionExecutedContext.HttpContext.Request.Body.Position = 0;
            //}
            //// Do whatever work with bodyStr here
            //var result = actionExecutedContext.Result;
            //if (!(result is null))
            //{
            //    var x = result.ExecuteResultAsync(actionExecutedContext);
            //    var status = result;
            //}
            //var _request = ReadAsString(actionExecutedContext.HttpContext.Response).Result;
            //var data = actionExecutedContext.HttpContext.Request.Headers["UserId"];
            //long UserId = Convert.ToInt64(actionExecutedContext.HttpContext.Request.Headers["UserId"]);
            //var _log = new HandleLogs();
            _log.Write(LogId,response);
            base.OnActionExecuted(actionExecutedContext);
        }
        private long GetLogId(ActionExecutedContext actionExecutedContext)
        {
            string logstring = "";

            var data = actionExecutedContext.HttpContext.Request.Headers["LogId"];
            if (data.Count > 0 && !(data.First().Equals("Bearer")))
            {
                if (actionExecutedContext.HttpContext.Request.Headers.TryGetValue("LogId", out var traceValue))
                {
                    logstring = traceValue;
                }
                if (!string.IsNullOrEmpty(logstring))
                {
                    
                    long LogId = Convert.ToInt64(logstring);
                    return LogId;
                }
            }

            return 0;
        }
        //public static async Task<string> ReadAsString( HttpResponse response)
        //{
        //    var initialBody = response.Body;
        //    var buffer = new byte[Convert.ToInt32(response.ContentLength)];
        //    await response.Body.ReadAsync(buffer, 0, buffer.Length);
        //    var body = Encoding.UTF8.GetString(buffer);
        //    response.Body = initialBody;
        //    return body;
        //}
        private async Task<string> ReadBodyAsString(HttpRequest request)
        {
            var initialBody = request.Body; // Workaround

            try
            {
                request.EnableBuffering();

                using (StreamReader reader = new StreamReader(request.Body))
                {
                    string text = await reader.ReadToEndAsync();
                    return text;
                }
            }
            finally
            {
                // Workaround so MVC action will be able to read body as well
                request.Body = initialBody;
            }
        }
    }
}
