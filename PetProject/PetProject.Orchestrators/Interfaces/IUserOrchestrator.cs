using PetProject.Entities.Models;

namespace PetProject.Orchestrators.Interfaces
{
    public interface IUserOrchestrator
    {
        public List<User> GetUsers();
        public User AddUser(User user);
        public string DeleteUser(User user);
        public string AuthorizationUser(string userName);
    }
}
