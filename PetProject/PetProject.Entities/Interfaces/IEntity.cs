namespace PetProject.Entities.Interfaces
{
    /// <summary>
    /// Общий интерфейс всех сущностей
    /// </summary>
    public interface IEntity<T> where T : struct
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        T Id { get; set; }
    }
}
