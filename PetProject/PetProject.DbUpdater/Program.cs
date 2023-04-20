using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetProject.DataContext.MsSql;
using System;
using PetProject.DataContext.Interfaces;
using CommandLine;
using PetProject.DbUpdater.Helpers;
using PetProject.DbUpdater.MigrationServices.Interfaces;
using PetProject.DbUpdater.MigrationServices.Implementations;

namespace PetProject.DbUpdater
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }
        private static ILogger<Program> mLogger;

        public static void ConfigurePostgreSqlServices(IServiceCollection services)
        {
            services.AddDbContext<IAppContext, MSSqlContext>(options =>
                options.UseSqlServer(Configuration.GetSection("Data:MSSQL:ConnectionString").Value));

            services.AddTransient<IMigrationService, MigrationPostgreSqlService>();
            services.AddLogging(logging => logging.AddConsole());
        }

        /// <summary>
        /// -m (выполнить миграцию),
        /// -r (пересоздать БД)
        /// -d (пересоздать БД с миграциями)
        /// -f (force)
        /// </summary>
        static void Main(string[] args)
        {
            //Парсинг ключей запуска приложения
            UpdateOptions options = null;
            Parser.Default.ParseArguments<UpdateOptions>(args).WithParsed(o => options = o);

            List<bool> keys = new List<bool> { options.Migrate, options.Recreate, options.Develop };

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

            IServiceProvider provider = services.BuildServiceProvider();
            IMigrationService migrator = provider.GetService<IMigrationService>();
            mLogger = provider.GetService<ILogger<Program>>();

            migrator.PrintConnectionString();

            //Применение миграций
            if (options.Migrate)
            {
                migrator.PrintMigrationState();
                if (migrator.IsExist())
                {
                    migrator.PrintListMigration();
                    //Если модель отличается то применяем миграции
                    if (!migrator.IsCompatible())
                    {
                        migrator.Migratе();
                    }

                    migrator.AddData();
                }
                else
                {
                    mLogger.LogWarning("БД не существует, миграция невозможна");
                    WaitAnyKey();
                    return;
                }
                migrator.PrintMigrationState();
            }

            //Пересоздание БД
            if (options.Develop)
            {
                migrator.Recreate(true);
                migrator.CreationSeed();
            }

            //Пересоздание БД с миграциями
            if (options.Recreate)
            {
                migrator.Recreate();
                migrator.CreationSeed();
            }

            WaitAnyKey();
        }

        private static void WaitAnyKey()
        {
            if (System.Diagnostics.Debugger.IsAttached || Environment.GetCommandLineArgs().Length == 0)
            {
                mLogger.LogInformation("Нажмите любую клавишу для продолжения");
                Console.ReadKey(true);
            }
        }
    }
}