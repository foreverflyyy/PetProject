using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetProject.Models;

namespace PetProject.Controllers
{
   //[ApiController]
   //[Route("{api/[controller]}"), AllowAnonymous]
   [Route("api/{controller}")]
   public class HomeController : ControllerBase
   {
      private readonly ILogger<HomeController> _logger;
      private readonly ITimeService timeService;

      public HomeController(ILogger<HomeController> logger, ITimeService timeServ)
      {
         _logger = logger;
         timeService = timeServ;
      }

      [HttpGet("index")]
      //[Route("index")]
      public IResult Index()
      {
         return Results.Ok($"<h2>Hello METANIT.COM!</h2>. Now time {timeService.Time}");
      }

      public IActionResult WrongRequest(string? name)
      {
         if (string.IsNullOrEmpty(name))
            return BadRequest("Name undefined");

         return Content($"Name: {name}");
      }

      [HttpGet]
      public string CheckWorking() => "Hello, all good!";

      [HttpPost]
      public string SetValue() => "Like i install value";
   }
}

