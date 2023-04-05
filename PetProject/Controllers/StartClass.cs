

namespace PetProject.Controllers 
{
    public class StartClass : IStartClass
    {
        static Random rnd = new Random();
        private int _value;
        public StartClass()
        {
            _value = rnd.Next(0, 1000000);
        }
        public int Value
        {
            get => _value;
        }
    }
}