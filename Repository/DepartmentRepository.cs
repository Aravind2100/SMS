using StudentManagementSystem.Database;
using StudentManagementSystem.Dto;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.Model;
namespace StudentManagementSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        SMSDbContext db;
        public DepartmentRepository(SMSDbContext db)
        {
            this.db = db;
        }

        public List<DepartmentDto> GetAllDepartment()
        {

            List<DepartmentDto> departments = new List<DepartmentDto>();
            foreach (var dep in db.Departments.ToList())
            {
                var d = new DepartmentDto
                {
                    Id = dep.Id,
                    Name = dep.Name,
                    HodName = dep.HodName
                };
                departments.Add(d);
            }
            return departments;
        }
        public Department GetDepartmentById(int Id)
        {
            var d = db.Departments.First(x => x.Id == Id);
            
            return d;
        }
        public string AddDepartment(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return "Created";
        }
        public string UpdateDepartment(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteDepartment(int Id)
        {
            var d = db.Departments.FirstOrDefault(x => x.Id == Id);
            db.Departments.Remove(d);
            db.SaveChanges();
            return "Deleted";
        }

    }
}
