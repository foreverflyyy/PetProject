using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace PetProject.DbUpdater.Helpers
{
    internal static class Extensions
    {
        public static bool Exists(this DatabaseFacade self)
        {
            var db = self.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            return db != null && db.Exists();
        }

        public static void CreateTables(this DatabaseFacade self)
        {
            var db = self.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (db != null) db.CreateTables();
        }

        public static bool CompatibleWithModel(this DatabaseFacade self)
        {
            return !self.GetPendingMigrations().Any();
        }

        public static bool Empty(this DatabaseFacade self)
        {
            return !self.GetAppliedMigrations().Any();
        }

    }
}
