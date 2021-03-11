using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyWebApi.MIddleware
{
    public class MyLoggingMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly ILogger<MyLoggingMiddleware> logger;
        private readonly IOptions<MySuperSection> options;

        public MyLoggingMiddleware(RequestDelegate requestDelegate, ILogger<MyLoggingMiddleware> logger, IOptions<MySuperSection> options)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
            this.options = options;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            logger.LogInformation(httpContext.Request.Path);
            logger.LogInformation("before next middleware");
            await requestDelegate(httpContext);
            logger.LogInformation("after next middleware");

        }
    }
}
