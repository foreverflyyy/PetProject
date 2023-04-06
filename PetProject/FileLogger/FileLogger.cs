

namespace PetProject.FileLogger
{
    // 
    public class FileLogger : ILogger, IDisposable
    {
        string filePath;
        static object _lock = new object();
        public FileLogger(string path)
        {
            filePath = path;
        }

        // метод возвращает объект IDisposable, который представляет некоторую область видимости для логгера
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }
    
        public void Dispose() { }
    
        // возвращает значения true или false, которые указыват, доступен ли логгер для использования
        // можем задать некоторую логику например если нужный logLevel, то ток тогда разрешаем использовать лог
        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }
        
        // LogLevel: уровень детализации текущего сообщения
        // EventId: идентификатор события
        // TState: некоторый объект состояния, который хранит сообщение
        // Exception: информация об исключении
        // formatter: функция форматирования, которая с помощью двух предыдущих параметов позволяет получить собственно сообщение для логгирования
        public void Log<TState>(LogLevel logLevel, EventId eventId,
                    TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}