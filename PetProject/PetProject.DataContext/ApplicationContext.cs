using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetProject.Models;

namespace PetProject.DataContext
{
    /// <summary>
    /// Базовый контекст
    /// </summary>
    public class ApplicationContext : DbContext, IAppContext, IUserContext
    {
        private static ILogger<ApplicationContext> mLogger;
        //private readonly ILoggerFactory mLoggerFactory;
        private static IConfigurationRoot Configuration { get; set; }
        
        public ApplicationContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            //OnConfiguring(options);
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        /// <summary>
        /// Создание схемы БД
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        // Замена явной инициализации свойств ссылочных типов, которые не инициализированны и при этом не допускают значение null
        public DbSet<User> Users { get; set; } = null!;
    }
}
