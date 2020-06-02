using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    public class MyErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public MyErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
                if (context.Response.StatusCode == 404)
                    throw new Exception("your requested page wasnt found :-(");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            //    var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            //    if (ex is MyNotFoundException) code = HttpStatusCode.NotFound;
            //    else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //    else if (ex is MyException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new {
                error = $"{ex.Message } you have a problem!"
                ,code= HttpStatusCode.InternalServerError });
            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)code;
             await context.Response.WriteAsync(result);
            //if (context.Response.StatusCode == 400)
            //{
            // return   context.Response.WriteAsync("validation error!!");
            //}
            //return context.Response.WriteAsync("different error");
        //  var r=  context.HttpContext..Features.Get<IExceptionHandlerPathFeature>();
        }
      
    }
}
