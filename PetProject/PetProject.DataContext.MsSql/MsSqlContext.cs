using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetProject.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PetProject.DataContext.MsSql
{
    public class MSSqlContext : BaseContext
    {
        public MSSqlContext(DbContextOptions<MSSqlContext> options, ILoggerFactory loggerFactory) : base(options, loggerFactory)
        {
        }
    }
}
