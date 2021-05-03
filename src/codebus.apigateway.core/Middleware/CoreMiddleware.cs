using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace codebus.apigateway.core.Middleware
{
    public static class CoreMiddleware
    {
        public static void UseCore(this IApplicationBuilder app)
        {
            app.UseGateway().Wait();
        }
    }
}
