using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http.Controllers;

namespace CarGuru.Filters
{
    public class APILogs : ActionFilterAttribute,IActionFilter
    {
        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    // our code before action executes
        //}

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            dynamic responseData = actionExecutedContext.HttpContext.Response.Body;
            dynamic v = responseData.Value;
            //var ip = actionExecutedContext.HttpContext;
            var javaScriptSerializer1 = new JavaScriptSerializer();
            //int UserId = Convert.ToInt32(actionExecutedContext.HttpContext.Request.Headers.Properties["UserId"]);
            // long UserId = Convert.ToInt64(actionExecutedContext.HttpContext.Request.Headers["x-correlation-id"].ToString());
            long UserId = 1;
            HandleLogs.Write(UserId, actionExecutedContext);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
