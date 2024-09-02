namespace StudentManagementSystem.Dto
{
    public class StudentDto
    {
        public required int Id { get; set; }
        public required int RoleNumber { get; set; }
        public required string Name { get; set; }
        public required string Gender { get; set; }
        public required DateTime Dob { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required int DepartmentId { get; set; }
    }
}
