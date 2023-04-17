using Microsoft.AspNetCore.Mvc;

namespace PetProject.Web.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class HomeController : ControllerBase
   {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger)
      {
         _logger = logger;
      }

      [Route("index/{id}")]
      [HttpGet]
      public IResult Index(int id)
      {
         return Results.Text($"everythings good! {id}!");
      }
   }
}
