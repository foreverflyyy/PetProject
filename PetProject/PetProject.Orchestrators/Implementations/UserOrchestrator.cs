using NLog;
using PetProject.Orchestrators.Interfaces;
using PetProject.Models;

namespace PetProject.Orchestrators.Implementations
{
    public class UserOrchestrator : IUserOrchestrator 
    {
        private static readonly Logger mLogger = LogManager.GetLogger("UserOrchestratorLogger");

        public UserOrchestrator() 
        {
            
        }

        public string GetUsers()
        {
            mLogger.Info("heloooooooooo");
            return "im user, wow!";
        }

        public string AddUser(User user)
        {


            return "";
        }
    }
}
