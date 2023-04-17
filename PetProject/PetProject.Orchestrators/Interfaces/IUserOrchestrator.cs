using PetProject.Models;

namespace PetProject.Orchestrators.Interfaces
{
    public interface IUserOrchestrator
    {
        public string GetUsers();
        public string AddUser(User user);
    }
}
