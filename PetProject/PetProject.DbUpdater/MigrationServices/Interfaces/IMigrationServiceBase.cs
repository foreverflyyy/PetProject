namespace PetProject.DbUpdater.MigrationServices.Interfaces
{
    public interface IMigrationServiceBase
    {
        /// <summary>
        /// Вывод строки подключения
        /// </summary>
        void PrintConnectionString();

        /// <summary>
        /// Существует ли БД
        /// </summary>
        bool IsExist();

        /// <summary>
        /// Список применённых и ожидающих применения миграций
        /// </summary>
        void PrintListMigration();

        /// <summary>
        /// Пересоздание БД
        /// </summary>
        void Recreate(bool develop = false);

        /// <summary>
        /// Выполнить миграцию
        /// </summary>
        void Migratе();

        /// <summary>
        /// Соответствует ли БД текущей модели
        /// </summary>
        /// <returns></returns>
        bool IsCompatible();

        /// <summary>
        /// Вывод состояния миграции
        /// </summary>
        void PrintMigrationState();
    }
}
