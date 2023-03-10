using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface IRepositoryContextFactory
    {
        public RepositoryContext CreateDbContext(string connectionString);
    }
}
