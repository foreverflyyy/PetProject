using Microsoft.AspNetCore.Mvc;
using PetProject.Orchestrators.Interfaces;
using PetProject.Models;
using PetProject.Orchestrators.Implementations;

namespace PetProject.Web.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class UserController : ControllerBase
   {
        private readonly ILogger<UserController> Logger;
        private readonly IUserOrchestrator mUserOrchestrator;

        public UserController(ILogger<UserController> logger,
            IUserOrchestrator userOrchestrator)
        {
            Logger = logger;
            mUserOrchestrator = userOrchestrator;
        }

        //[Route("index/{id}")]
        [HttpGet]
        public string GetUsers()
        {
            Logger.LogWarning($"Enter in methid GetUsers with path: /api/users/");
            string user = mUserOrchestrator.GetUsers();
            return $"everythings good!! {user}";
        }
        
        //[Route("index/{id}")]
        [HttpPost]
        public IResult AddUsers()
        {
            Logger.LogWarning($"Enter in methid GetUsers with path: /api/users/");
            return Results.Text($"everythings good!!");
        }
    }
}
