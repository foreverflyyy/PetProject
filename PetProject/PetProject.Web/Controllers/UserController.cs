using Microsoft.AspNetCore.Mvc;
using PetProject.Orchestrators.Interfaces;
using PetProject.Models;
using NLog;
using PetProject.Orchestrators.Implementations;

namespace PetProject.Web.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class UserController : ControllerBase
   {
        private static readonly Logger mLogger = LogManager.GetLogger("UserControllerLogger");
        private readonly IUserOrchestrator mUserOrchestrator;

        public UserController(IUserOrchestrator userOrchestrator)
        {
            mUserOrchestrator = userOrchestrator;
        }

        //[Route("index/{id}")]
        [HttpGet]
        public string GetUsers()
        {
            mLogger.Info($"Enter in methid GetUsers with path: /api/users/");
            string user = mUserOrchestrator.GetUsers();
            return $"everythings good!! {user}";
        }
        
        //[Route("index/{id}")]
        [HttpPost]
        public IResult AddUsers()
        {
            mLogger.Info($"Enter in methid GetUsers with path: /api/users/");
            return Results.Text($"everythings good!!");
        }
    }
}
