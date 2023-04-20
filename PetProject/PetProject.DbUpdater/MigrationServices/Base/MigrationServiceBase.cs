using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Neolant.NsPlugin.DataAccess.Interfaces;
using PetProject.DataContext.Interfaces;
using PetProject.DbUpdater.Helpers;
using PetProject.DbUpdater.MigrationServices.Interfaces;

namespace PetProject.DbUpdater.MigrationServices.Base
{
    public abstract class MigrationServiceBase : IMigrationServiceBase
    {
        protected readonly IAppContext Context;
        protected readonly ILogger mLogger;

        protected MigrationServiceBase(IAppContext context, ILogger<MigrationServiceBase> logger)
        {
            Context = context;
            mLogger = logger;
        }

        /// <inheritdoc />
        public void PrintConnectionString()
        {
            mLogger.LogWarning($"ConnectionString: {Context.Database.GetDbConnection().ConnectionString}");
        }

        /// <inheritdoc />
        public bool IsExist()
        {
            return Context.Database.Exists();
        }

        /// <inheritdoc />
        public void PrintListMigration()
        {
            if (IsExist())
            {
                var applied = FilterOutMigrationName(Context.Database.GetAppliedMigrations()).ToList();
                if (applied.Any())
                {
                    mLogger.LogInformation("Применённые миграции: " + applied.Aggregate((a, v) => a + ", " + v));
                }

                var updates =
                    FilterOutMigrationName(Context.Database.GetPendingMigrations())
                        .ToList(); //GetMigrationHistory(ctx);

                if (updates.Any())
                {
                    mLogger.LogWarning("Миграции ожидающие применения: " + updates.Aggregate((a, v) => a + ", " + v));
                }
            }
        }

        /// <inheritdoc />
        public void Recreate(bool develop = false)
        {
            Console.WriteLine("Пересоздание базы данных");
            byte countAttemps = 0;

            while (Context.Database.Exists())
            {
                if (countAttemps >= 5)
                {
                    mLogger.LogWarning("Превышено число попыток удаления, операция будет прервана");
                    break;
                }

                try
                {
                    mLogger.LogWarning("Попытка удаления");
                    Context.Database.EnsureDeleted();
                    mLogger.LogInformation("Удалено");
                    break;
                }
                catch (Exception e)
                {
                    countAttemps++;
                    mLogger.LogError("Ошибка удаления: " + e.Message);
                    mLogger.LogInformation("Повтор");
                    Thread.Sleep(3000);
                }

            }

            if (!Context.Database.Exists())
            {
                if (develop)
                    Context.Database.EnsureCreated();
                else
                    Context.Database.Migrate();
            }
        }

        /// <inheritdoc />
        public void Migratе()
        {
            Context.Database.Migrate();
        }

        /// <inheritdoc />
        public bool IsCompatible()
        {
            return IsExist() && Context.Database.CompatibleWithModel();
        }

        /// <inheritdoc />
        public void PrintMigrationState()
        {
            var dbExist = Context.Database.Exists();
            var dbCompat = dbExist && Context.Database.CompatibleWithModel();

            mLogger.LogInformation("Результат проверки модели БД ->");
            mLogger.LogInformation("БД существует:\t" + dbExist);
            mLogger.LogInformation("Модель совместима:\t" + dbCompat);
        }

        private IEnumerable<string> FilterOutMigrationName(IEnumerable<string> mirgations)
        {
            return mirgations.Select(i => i.Contains("_") ? i.Split('_')[0] : i);
        }
    }
}
