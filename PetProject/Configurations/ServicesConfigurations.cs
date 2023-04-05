using PetProject.Controllers;

namespace PetProject.Configuration
{
    /// <summary>
    /// Класс расширений для регистрации сервисов в приложении
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Регистрация сервисов Context
        /// </summary>
        public static void ReigstrationUserPostgreSqlServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            
        }

        /// <summary>
        /// Регистрация оркестраторов
        /// </summary>
        public static void AddOrchestrators(this IServiceCollection services, IConfiguration configuration)
        {
            // Scoped - в рамках одного запроса внедряется один и тот же экземпляр          
            services.AddScoped<IStartClass, StartClass>();
        }
    }
}