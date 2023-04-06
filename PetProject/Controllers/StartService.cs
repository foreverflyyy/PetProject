

namespace PetProject.Controllers
{
    public interface IReadText
    {
        public int Read();
    }

    public interface IGenerateText
    {
        public int Generate();
    }

    public class StartService : IReadText, IGenerateText
    {
        int value;

        public int Generate()
        {
            value = new Random().Next();
            return value;
        }

        public int Read() => value;
    }
}