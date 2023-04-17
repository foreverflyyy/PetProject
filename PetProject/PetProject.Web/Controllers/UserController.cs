using Microsoft.AspNetCore.Mvc;
using PetProject.Orchestrators.Interfaces;
using PetProject.Models;
using NLog;
using PetProject.Orchestrators.Implementations;
using System.Diagnostics.Metrics;

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
        public List<User> GetUsers()
        {
            mLogger.Info($"Enter in Controller method GetUsers.");
            List<User> users = mUserOrchestrator.GetUsers();
            return users;
        }
        
        //[Route("index/{id}")]
        [HttpPost]
        public User AddUsers(User user)
        {
            mLogger.Info($"Enter in Controller method AddUsers");
            User newUser = mUserOrchestrator.AddUser(user);
            return newUser;
        }
    }
}
