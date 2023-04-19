using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PetProject.Orchestrators.Interfaces;
using PetProject.Orchestrators.Implementations;

namespace PetProject.Web.Configuration
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
            services.AddDbContext<PostgreSqlContext>(options => options.UseSqlServer(configuration.GetSection("Data:MSSQL:ConnectionString").Value), ServiceLifetime.Transient);
            services.AddDbContext<IUserContext, PostgreSqlContext>();
        }

        /// <summary>
        /// Регистрация оркестраторов
        /// </summary>
        public static void AddOrchestrators(this IServiceCollection services, IConfiguration configuration)
        {
            // Scoped - в рамках одного запроса внедряется один и тот же экземпляр          
            services.AddScoped<IUserOrchestrator, UserOrchestrator>();
        }
    }
}
