using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetProject.Entities.Interfaces;

namespace PetProject.Entities.Base
{
    /// <summary>
    /// Базовый класс всех сущностей
    /// </summary>
    public abstract class BaseEntity<T> : IEquatable<BaseEntity<T>>, IEntity<T> where T : struct
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Description("Идентификатор")]
        public T Id { get; set; }

        public bool Equals(BaseEntity<T> other)
        {
            if (other == null)
                return false;

            return Id.Equals(other.Id);
        }
    }
}
