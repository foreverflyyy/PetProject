

namespace PetProject.Controllers
{
    public class StartService
    {
        public IStartClass Counter { get; }
        public StartService(IStartClass counter)
        {
            Counter = counter;
        }
    }
}