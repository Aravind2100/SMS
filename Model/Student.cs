using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required int Id { get; set; }
        public required int RoleNumber { get; set; }
        public required string Name { get; set; }
        public Gender gender { get; set; }
        public required DateTime Dob { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required int DepartmentId { get; set; }

        public Department department { get; set; }
    }

    public enum Gender
    {
        male,
        female
    }
}
