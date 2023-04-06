

namespace PetProject.FileLogger
{
    // представляет провайдер логгирования
    public class FileLoggerProvider : ILoggerProvider
    {
        string path;
        public FileLoggerProvider(string path)
        {
            this.path = path;
        }

        // создает и возвращает объект логгера. Для создания логгера используется путь к файлу, который передается через конструктор
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        //  управляет освобождение ресурсов
        public void Dispose() {}
    }
}