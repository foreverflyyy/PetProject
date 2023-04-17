using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetProject.Models;

namespace PetProject.DbUpdater
{
    public class ApplicationContext : DbContext
    {
        //private static ILogger<ApplicationContext> mLogger;
        private static IConfigurationRoot Configuration { get; set; }

        // Замена явной инициализации свойств ссылочных типов, которые не инициализированны и при этом не допускают значение null
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext()
        {
            //OnConfiguring(options);
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
