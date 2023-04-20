using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace PetProject.DataContext.Interfaces
{
    /// <summary>
    /// Базовый интерфейс контекста
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Таблица БД
        /// </summary>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Таблица БД
        /// </summary>
        //DbQuery<T> Query<T>() where T : class;

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// БД
        /// </summary>
        DatabaseFacade Database { get; }

        /// <summary>
        /// Трекер изменений
        /// </summary>
        ChangeTracker ChangeTracker { get; }

        /// <summary>
        /// Сохранить изменения асинхронно
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Добавить нетипизированную сущность
        /// </summary>
        EntityEntry Add(object entity);

        /// <summary>
        /// Добавить сущности
        /// </summary>
        void AddRange(params object[] entities);

        /// <summary>
        /// Обновить нетипизированную сущность
        /// </summary>
        EntityEntry Update(object entity);

        /// <summary>
        /// Обновить сущности
        /// </summary>
        void UpdateRange(params object[] entities);

        /// <summary>
        /// Привязать сущность к контексту
        /// </summary>
        EntityEntry Entry(object entity);
    }
}
