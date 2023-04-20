using NLog;
using PetProject.Orchestrators.Interfaces;
using PetProject.Models;
using PetProject.DataContext.MsSql;

namespace PetProject.Orchestrators.Implementations
{
    public class UserOrchestrator : IUserOrchestrator 
    {
        private static readonly Logger mLogger = LogManager.GetLogger("UserOrchestratorLogger");
        private readonly MSSqlContext mContext;
        public UserOrchestrator(MSSqlContext context) 
        {
            mContext= context;
        }

       /* List<User> users = new List<User>() { new User() { Id = Guid.NewGuid(), Name = "Nekit", Age = 20},
                            new User() { Id = Guid.NewGuid(), Name = "Max", Age = 21}};*/

        public List<User> GetUsers()
        {
            mLogger.Info("Start GET Orchestrator method GetUsers");

            var users = mContext.Users.ToList();

            return users;
        }

        public User AddUser(User user)
        {
            mLogger.Info("Start Post Orchestrator method AddUser");

            user.Id = Guid.NewGuid();
            mContext.Users.Add(user);

            mContext.SaveChanges();
            return user;
        }
    }
}
