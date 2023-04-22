using PetProject.Orchestrators.Interfaces;
using PetProject.Orchestrators.Implementations;
using PetProject.DataContext.MSSql;
using Microsoft.EntityFrameworkCore;
using PetProject.DataContext.Interfaces;
using PetProject.DataAccess.Repositories.Interfaces;
using PetProject.DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        public static void RegistrationUserMsSqlServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MSSqlContext>(options => options.UseSqlServer(configuration.GetSection("Data:MSSQL:ConnectionString").Value), ServiceLifetime.Transient);
            services.AddDbContext<IUserContext, MSSqlContext>();
        }

        /// <summary>
        /// Регистрация сервисов предоставления данных
        /// </summary>
        public static void AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,,>), typeof(BaseRepository<,,>));
        }

        /// <summary>
        /// Регистрация оркестраторов
        /// </summary>
        public static void AddOrchestrators(this IServiceCollection services, IConfiguration configuration)
        {
            // Scoped - в рамках одного запроса внедряется один и тот же экземпляр          
            services.AddScoped<IUserOrchestrator, UserOrchestrator>();
        }
        
        /// <summary>
        /// Регистрация авторизации и токена
        /// </summary>
        public static void AddAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // указывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });
        }

        /// <summary>
        /// Регистрация сервисов кэширования
        /// </summary>
        public static void AddCacheService(this IServiceCollection services)
        {
            /*services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<INSDataMapService, NSDataMapService>();
            services.AddScoped<ApiNSHelper>();*/
        }
    }

    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
