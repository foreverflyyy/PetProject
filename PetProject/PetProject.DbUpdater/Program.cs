using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetProject.DataContext.MsSql;
using System;


namespace PetProject.DbUpdater
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        public static void ConfigurePostgreSqlServices(IServiceCollection services)
        {
            services.AddDbContext<IAppContext, MsSqlContext>(options =>
            options.UseSqlServer(Configuration.GetSection("Data:MSSQL:ConnectionString").Value));

            /*services.AddScoped(typeof(IDatabaseSchemaHelper<>), typeof(PostgreSqlDatabaseSchemaHelper<>));
            services.AddTransient<IMigrationService, MigrationPostgreSqlService>();
            services.AddLogging(logging => logging.AddConsole());*/
        }

        private static ILogger<Program> mLogger;

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            
            var configBuilder = new ConfigurationBuilder()
                // установка пути к текущему каталогу
                .SetBasePath(Directory.GetCurrentDirectory())
                // получаем конфигурацию из файла appsettings.json
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>();

            Configuration = configBuilder.Build();
            services.AddScoped(x => Configuration);
            ConfigurePostgreSqlServices(services);
        }
    }
}