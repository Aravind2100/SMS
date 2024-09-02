using StudentManagementSystem.Dto;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.IRepository
{
    public interface IDepartmentRepository
    {
        public List<DepartmentDto> GetAllDepartment();
        public Department GetDepartmentById(int Id);
        public string AddDepartment(Department department);
        public string UpdateDepartment(Department department);
        public string DeleteDepartment(int Id);
    }
}
