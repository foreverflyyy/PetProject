using Microsoft.AspNetCore.Mvc;
using PetProject.Orchestrators.Interfaces;
using PetProject.Entities.Models;
using NLog;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost("delete")]
        public IResult DeleteUser(User user)
        {
            mUserOrchestrator.DeleteUser(user);
            return Results.Ok();
        }

        [Authorize]
        [HttpGet("info")]
        public IResult StatusAuthorization()
        {
            return Results.Text("You are authorizated!");
        }

        [HttpPost("login")]
        public string AuthorizationUser(string userName)
        {
            string token = mUserOrchestrator.AuthorizationUser(userName);
            return token;
        }
    }
}
