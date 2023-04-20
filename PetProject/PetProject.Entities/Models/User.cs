using PetProject.Entities.Base;

namespace PetProject.Entities.Models
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}