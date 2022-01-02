using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyMinecraftSaverAPI.Exceptions;

namespace MyMinecraftSaverAPI.Exceptions
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
