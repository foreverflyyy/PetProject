namespace PetProject.DbUpdater.MigrationServices.Interfaces
{
    public interface IMigrationService : IMigrationServiceBase
    {
        /// <summary>
        /// Инициализация БД при её создании
        /// </summary>
        void CreationSeed();

        /// <summary>
        /// Заполнение данных
        /// </summary>
        void AddData();
    }
}
