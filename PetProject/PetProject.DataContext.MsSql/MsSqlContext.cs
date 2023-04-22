using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PetProject.DataContext.MSSql
{
    public class MSSqlContext : BaseContext
    {
        public MSSqlContext(DbContextOptions<MSSqlContext> options, ILoggerFactory loggerFactory) : base(options, loggerFactory)
        {
        }
    }
}
