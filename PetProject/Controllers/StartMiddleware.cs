using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProject.Extensions;

namespace PetProject.Controllers
{
    //public class StartMiddleware : ControllerBase
    public class StartMiddleware
    {
        RequestDelegate next;
        int i = 0; // счетчик запросов
        public StartMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IStartClass start, StartService startService)
        {
            i++;
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync($"Запрос {i}; Counter: {start.Value}; Service: {startService.Counter.Value}");
        }
    }
}

