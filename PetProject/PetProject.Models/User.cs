

namespace PetProject.Models
{
    public class User
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }

    /*public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; } // �������� ��������
        public List<User> Users { get; set; } = new();
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CompanyId { get; set; }      // ������� ����
        public Company? Company { get; set; }    // ������������� ��������
    }*/
}