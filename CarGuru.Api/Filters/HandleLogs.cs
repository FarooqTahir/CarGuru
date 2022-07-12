using CarGuru.Api.Filters;
using CarGuru.Database.Dtos;
using CarGuru.Services.Interfaces;
using CarGuru.Services.Services;
using CarGuru.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Filters
{
    public class HandleLogs :IHangleLog
    {
        private readonly ILogService _log;
        public HandleLogs(ILogService log)
        {
            _log = log;
        }
        public bool Write(long logId,string response)
        {
            _log.UpdateAPILogs(logId, response);
            return true;
        }
        private long GetUserId(ActionExecutingContext actionExecutedContext)
        {
            string tokenstring = "";

            var data = actionExecutedContext.HttpContext.Request.Headers["Authorization"];
            if (data.Count > 0 && !(data.First().Equals("Bearer")))
            {
                if (actionExecutedContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var traceValue))
                {
                    tokenstring = traceValue;
                }
                if (!string.IsNullOrEmpty(tokenstring))
                {
                    var jwtEncodedString = tokenstring.Substring(7); // trim 'Bearer ' from the start
                    var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
                    long userId = Convert.ToInt64(token.Claims.First(c => c.Type == SessionStrings.UserId).Value);
                    return userId;
                }
            }

            return 0;
        }
        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"{response.StatusCode}: {text}";
        }

        public long Add(ActionExecutingContext context)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            string requestedController = (string)context.RouteData.Values["Controller"];
            string requestedAction = (string)context.RouteData.Values["Action"];
            string request = "";
             if(context.ActionArguments.Count > 0) request = javaScriptSerializer.Serialize(context.ActionArguments.First().Value);
            long UserId = GetUserId(context);
            APILogDto logs = new APILogDto()
            {
                UserId = UserId,
                ActionName = requestedAction,
                ControllerName = requestedController,
                FunctionRequest = javaScriptSerializer.Serialize(request),
                //FunctionRequest = Security.Encrypt(request, SecurityKey.PasswordKey),
                //FunctionResponse = javaScriptSerializer.Serialize(responseData),
                IPAddress = "",
                CreatedDate = DateTime.UtcNow
            };
            long LogId = _log.AddAPILogs(logs);
            return LogId;
        }
    }
}
