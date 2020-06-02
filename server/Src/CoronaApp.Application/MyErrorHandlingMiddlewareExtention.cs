using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api
{
    public static class MyErrorHandlingMiddlewareExtention
    {
        public static IApplicationBuilder ConfigureMyErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyErrorHandlingMiddleware>();

        }
    }
}
