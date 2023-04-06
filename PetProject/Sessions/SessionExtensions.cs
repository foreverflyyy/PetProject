using System.Text.Json;

namespace PetProject.Sessions
{
    public static class SessionExtensions
    {
        // Метод, если у нас сложный объект для передачи в куки, то мы его сериализовываем
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }
    
        // Метод для десериализации значения из сессии
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}