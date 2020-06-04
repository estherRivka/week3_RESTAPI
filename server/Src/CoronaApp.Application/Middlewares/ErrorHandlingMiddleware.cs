using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Serilog;
using System.IO;
using CoronaApp.Api.Exceptions;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {

            await _next(context);
            //if (context.Response.StatusCode == 400)
            //{

            //    context.Response.WriteAsync("bad request");

            //}

        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        if (ex is PatientNotExistExcption)
        {
            code = HttpStatusCode.NoContent;
        }



        string result = JsonSerializer.Serialize(new { errorMessage = ex.Message, statusCode = code });
      
        Log.Error(ex, "errot caught in ErrorHandlingMiddleware");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsync(result);
        
    }
    
}
public static class ErrorHandlingMiddlewareExtentions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}