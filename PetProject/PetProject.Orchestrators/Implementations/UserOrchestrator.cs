using NLog;
using PetProject.Orchestrators.Interfaces;
using PetProject.Models;
using System.Text.Json;

namespace PetProject.Orchestrators.Implementations
{
    public class UserOrchestrator : IUserOrchestrator 
    {
        private static readonly Logger mLogger = LogManager.GetLogger("UserOrchestratorLogger");

        public UserOrchestrator() 
        {
            
        }

        List<User> users = new List<User>() { new User() { Id = Guid.NewGuid(), Name = "Nekit", Age = 20} };

        public List<User> GetUsers()
        {
            mLogger.Info("Start GET Orchestrator method GetUsers");

            users.Add(new User() { Id = Guid.NewGuid(), Name = "Max", Age = 21});

            return users;
        }

        public User AddUser(User user)
        {
            mLogger.Info("Start Post Orchestrator method AddUser");

            user.Id = Guid.NewGuid();
            users.Add(user);
            return user;
        }
    }
}
