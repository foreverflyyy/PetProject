using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProject.Extensions;

namespace PetProject.Controllers
{
    //public class StartMiddleware : ControllerBase
    public class ReadMiddleware
    {
        RequestDelegate next;
        public ReadMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IReadText readText)
        {
            if(context.Request.Path == "/read")
                await context.Response.WriteAsync($"Read number: {readText.Read()}");
            else
                await next.Invoke(context);
        }
    }

    public class GenerateMiddleware
    {
        RequestDelegate next;
        public GenerateMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IGenerateText generate)
        {
            if(context.Request.Path == "/generate")
                await context.Response.WriteAsync($"Generate number: {generate.Generate()}");
            else
                await next.Invoke(context);
        }
    }
}

