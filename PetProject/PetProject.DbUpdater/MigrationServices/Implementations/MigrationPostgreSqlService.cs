using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetProject.DataContext.Interfaces;
using PetProject.DbUpdater.Helpers;
using PetProject.DbUpdater.MigrationServices.Base;
using PetProject.DbUpdater.MigrationServices.Interfaces;
using PetProject.DataContext.DataFiller;

namespace PetProject.DbUpdater.MigrationServices.Implementations
{
    public class MigrationPostgreSqlService : MigrationServiceBase, IMigrationService
    {
        private readonly string mConnectionString;

        public MigrationPostgreSqlService(IAppContext context, IConfigurationRoot configuration, ILogger<MigrationServiceBase> logger) : base(context, logger)
        {
            // MSSQL
            mConnectionString = configuration.GetSection("Data:MSSQL:ConnectionString").Value;
        }

        /// <inheritdoc />
        public void CreationSeed()
        {
            //AddRoles();
            AddData();
            //EnableSnapshot();
        }

        public void AddData()
        {
            Context.Seed(mLogger);
        }

        /*private void AddRoles()
        {
            Context.Database.ExecuteSqlCommand(DbScriptBuilder.AddDbRolesScript());
        }

        private void EnableSnapshot()
        {
            Context.Database.ExecuteSqlCommand(DbScriptBuilder.EnableSnapshot());
        }*/
    }
}
