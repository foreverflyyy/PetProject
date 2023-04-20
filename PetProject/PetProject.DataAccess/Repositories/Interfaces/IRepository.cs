using PetProject.DataContext.Interfaces;
using PetProject.Entities.Base;

namespace PetProject.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий для работы с сущностями
    /// </summary>
    public interface IRepository<TContext, TEntity, T>
        where TEntity : BaseEntity<T>
        where TContext : class, IContext
    where T : struct
    {
        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <param name="tracking">Отслеживание контекстом</param>
        IQueryable<TEntity> GetAll(bool tracking = false);

        /// <summary>
        /// Вернуть сущность по идентификатору
        /// </summary>
        TEntity GetById(T id);

        /// <summary>
        /// Присутствует ли сущность в контексте
        /// </summary>
        bool Exists(T id);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// Добавить коллекцию сущностей
        /// </summary>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновить сущность (функцию нужно вызывать, только если объект не отслеживается в текущем контексте)
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// Удалить сущность из контекста
        /// </summary>
        void Remove(TEntity entity);

        /// <summary>
        /// Удалить сущность из контекста по идентификатору
        /// </summary>
        void Remove(T id);

        /// <summary>
        /// Удалить сущности по идентификторам
        /// </summary>
        void RemoveRange(IEnumerable<T> ids);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Сохранить изменения и очистить сущности из контекста
        /// </summary>
        /// <remarks>Использовать в случае, когда необходимо, чтобы контекст возвращал новые сущности взамен ранее закэшированных</remarks>
        void SaveChangesAndDetach();
    }
}
