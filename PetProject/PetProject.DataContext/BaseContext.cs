using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetProject.DataContext.Interfaces;
using PetProject.Entities.Models;

namespace PetProject.DataContext
{
    /// <summary>
    /// Базовый контекст
    /// </summary>
    public class BaseContext : DbContext, IAppContext, IUserContext
    {
        //private static ILogger<BaseContext> mLogger;
        private readonly ILoggerFactory mLoggerFactory;
        private static IConfigurationRoot Configuration { get; set; }
        
        public BaseContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            mLoggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(mLoggerFactory);
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        /// <summary>
        /// Создание схемы БД
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<TaskStep>().HasIndex(x => x.Type).IsUnique();
        }

        // Замена явной инициализации свойств ссылочных типов, которые не инициализированны и при этом не допускают значение null
        public DbSet<User> Users { get; set; } = null!;
    }
}
