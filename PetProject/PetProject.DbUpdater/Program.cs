using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetProject.DbUpdater;
using PetProject.Models;

var builder = new ConfigurationBuilder();

// установка пути к текущему каталогу
builder.SetBasePath(Directory.GetCurrentDirectory());

// получаем конфигурацию из файла appsettings.json
builder.AddJsonFile("appsettings.json");

// создаем конфигурацию
var config = builder.Build();
// получаем строку подключения

string connectionString = config.GetConnectionString("Data:MSSQL:ConnectionString");

var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
var options = optionsBuilder.UseSqlServer(connectionString).Options;

using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.ToList();
    foreach (User user in users)
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
}

/*using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace PetProject.DbUpdater
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        public static void ConfigurePostgreSqlServices(IServiceCollection services)
        {
            // MsSQL
            *//*services.AddDbContext<IAppContext, PostgreSqlContext>(options =>
            options.UseSqlServer(Configuration.GetSection("Data:MSSQL:ConnectionString").Value));

            services.AddScoped(typeof(IDatabaseSchemaHelper<>), typeof(PostgreSqlDatabaseSchemaHelper<>));
            services.AddTransient<IMigrationService, MigrationPostgreSqlService>();

            services.AddLogging(logging => logging.AddConsole());*//*
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
}*/