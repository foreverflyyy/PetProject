

namespace PetProject.FileLogger
{
    public static class FileLoggerExtensions
    {
        // добавляет к объекту ILoggingBuilder метод расширения AddFile, который будет добавлять наш провайдер логгирования.
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filePath)
        {
            builder.AddProvider(new FileLoggerProvider(filePath));
            return builder;
        }
    }
}