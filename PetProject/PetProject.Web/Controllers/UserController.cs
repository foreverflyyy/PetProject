using Microsoft.AspNetCore.Mvc;

namespace PetProject.Web.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class UsersController : ControllerBase
   {
      private readonly ILogger<UsersController> _logger;

      public UsersController(ILogger<UsersController> logger)
      {
         _logger = logger;
      }

      [Route("index/{id}")]
      [HttpGet]
      public IResult GetUsers(int id)
      {
         return Results.Text($"everythings good! {id}!");
      }
   }
}
