using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Interfaces;

namespace DBRepository
{
    public class RepositoryContextFactory : IRepositoryContextFactory
    {
        /// <summary>
        /// Конфигурируем dbcontext для работы с SQL Server
        /// </summary>
        /// <param name="connectionString"> Строка подключения </param>
        /// <returns></returns>
        public RepositoryContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(connectionString); // Передача строки подключения к бд

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
