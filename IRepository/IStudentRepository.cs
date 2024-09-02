using StudentManagementSystem.Dto;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.IRepository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public Student GetStudentById(int Id);
        public string AddStudent(Student student);
        public string UpdateStudent(Student student);
        public string DeleteStudent(int Id);
    }
}
