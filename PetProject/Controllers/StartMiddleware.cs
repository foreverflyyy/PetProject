using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProject.Extensions;
using Microsoft.Extensions.Options;
using System.Text;

namespace PetProject.Controllers
{
    //public class StartMiddleware : ControllerBase
    class PersonMiddleware
    {
        private readonly RequestDelegate next;
        public Person Person { get; }
        public PersonMiddleware(RequestDelegate next, IOptions<Person> options)
        {
            this.next = next;
            Person = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            StringBuilder stringBuilder = new();
            context.Response.ContentType = "text/html; charset=utf-8";
            stringBuilder.Append($"<p>Name: {Person.Name}</p>");
            stringBuilder.Append($"<p>Age: {Person.Age}</p>");
            stringBuilder.Append($"<p>Company: {Person.Company?.Title}</p>");
            stringBuilder.Append("<p>Languages:</p><ul>");
            foreach (var lang in Person.Languages)
            {
                stringBuilder.Append($"<li><p>{lang}</p></li>");
            }
            stringBuilder.Append("</ul>");
        
            await context.Response.WriteAsync(stringBuilder.ToString());
        }
    }

    public class Person
    {
        public string Name { get; set;} = "";
        public int Age { get; set; }
        public List<string> Languages { get; set; } = new();
        public Company? Company { get; set; }
    }

    public class Company 
    {
        public string Country { get; set; } = "";
        public string Title { get; set; } = "";
    }
}

