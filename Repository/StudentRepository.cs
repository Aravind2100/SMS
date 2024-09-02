using StudentManagementSystem.Database;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.Model;
namespace StudentManagementSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public readonly SMSDbContext Db;
        public StudentRepository(SMSDbContext db)
        {
            this.Db = db;
        }
        public List<Student> GetAllStudents()
        {
            var students = Db.Students.ToList();
            return students;
        }

        public Student GetStudentById(int Id)
        {
            return Db.Students.First(s => s.Id == Id);
        }
        public string AddStudent(Student student)
        {
            Db.Students.Add(student);
            Db.SaveChanges();
            return "Created";
        }
        public string UpdateStudent(Student student)
        {
            Db.Students.Update(student);
            Db.SaveChanges();
            return "updated";
        }
        public string DeleteStudent(int Id)
        {
            var s = Db.Students.First(s => s.Id == Id);

            Db.Students.Remove(s);
            Db.SaveChanges();
            return "Deleted";
        }
    }
}
