using NLog;
using PetProject.Orchestrators.Interfaces;
using PetProject.Entities.Models;
using PetProject.DataContext.MsSql;
using PetProject.DataContext.Interfaces;
using PetProject.DataAccess.Repositories.Interfaces;

namespace PetProject.Orchestrators.Implementations
{
    public class UserOrchestrator : IUserOrchestrator 
    {
        private static readonly Logger mLogger = LogManager.GetLogger("UserOrchestratorLogger");
        private readonly MSSqlContext mContext;

        private readonly IRepository<IUserContext, User, Guid> mUser;

        public UserOrchestrator(MSSqlContext context, IRepository<IUserContext, User, Guid> user) 
        {
            mContext= context;
            mUser = user;
        }

        public List<User> GetUsers()
        {
            mLogger.Info("Start GET Orchestrator method GetUsers");

            var users = mUser.GetAll().ToList();

            return users;
        }

        public User AddUser(User user)
        {
            mLogger.Info("Start Post Orchestrator method AddUser");
            mUser.Add(user);

            mUser.SaveChanges();
            return user;
        }
    }
}
