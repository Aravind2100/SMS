using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Dto;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Controllers
{
    [Route("Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepository IStudentRepository;
        public StudentController(IStudentRepository IStudentRepository)
        {
            this.IStudentRepository = IStudentRepository;
        }

        //GET ALL END POINT
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<StudentDto>> GetAll()
        {
            try
            {
                List<StudentDto> students = new List<StudentDto>();
                foreach (var student in IStudentRepository.GetAllStudents())
                {
                    StudentDto s = new StudentDto
                    {
                        Id = student.Id,
                        Name = student.Name,
                        RoleNumber = student.RoleNumber,
                        Dob = student.Dob,
                        Email = student.Email,
                        Address = student.Address,
                        City = student.City,
                        State = student.State,
                        DepartmentId = student.DepartmentId,
                        Gender = student.gender.ToString()
                    };
                    students.Add(s);
                }
                if (students != null) return Ok(students);
                else return NotFound("There are no Students");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Try Again");
            }

        }

        //CREATE END POINT
        [HttpPost]
        [Route("Create")]
        public ActionResult CreateStudent(StudentDto studentDto)
        {
            try
            {
                Gender gender;
                if (studentDto.Gender.ToLower() == "male") gender = Gender.male;
                else if (studentDto.Gender.ToLower() == "female") gender = Gender.female;
                else return BadRequest("Enter valid Gender");

                var student = new Student
                {
                    Id = studentDto.Id,
                    Name = studentDto.Name,
                    RoleNumber = studentDto.RoleNumber,
                    Dob = studentDto.Dob,
                    Email = studentDto.Email,
                    City = studentDto.City,
                    State = studentDto.State,
                    Address = studentDto.Address,
                    gender = gender,
                    DepartmentId = studentDto.DepartmentId
                };

                if (!student.Email.Contains("@"))
                {
                    return BadRequest("Entered value '" + student.Email + "' is not in Correct Formate");
                }
                var s = IStudentRepository.AddStudent(student);
                return Ok(s);

            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return StatusCode(500, " Id " + studentDto.Id + " is already Taken!");
            }
            catch (System.Exception)
            {
                return StatusCode(500,"Try Again");
            }
        }

        //GET BY ID ENDPOINT
        [HttpGet]
        [Route("GetById")]
        public ActionResult<StudentDto> GetById(int Id)
        {
            try
            {
                var s = IStudentRepository.GetStudentById(Id);
                StudentDto st = new StudentDto { 
                Id = s.Id,
                Name = s.Name,
                RoleNumber = s.RoleNumber,
                Dob = s.Dob,
                Email = s.Email,
                City = s.City,
                State = s.State,
                Address = s.Address,
                Gender = s.gender.ToString(),
                DepartmentId = s.DepartmentId
                };

                if (st != null) return Ok(st);
                else return NotFound();
            }
            
            catch (System.InvalidOperationException)
            {
                return StatusCode(500, "Student With Id " + Id + " is Not Found");
            }
        }

        // UPDATE END POINT
        [HttpPut]
        [Route("Update")]
        public ActionResult UpdateStudent(StudentDto studentDto)
        {
            try {
                Gender gender;
                if (studentDto.Gender.ToLower() == "male") gender = Gender.male;
                else if (studentDto.Gender.ToLower() == "female") gender = Gender.female;
                else return BadRequest("Enter valid Gender");

                var student = new Student
                {
                    Id = studentDto.Id,
                    Name = studentDto.Name,
                    RoleNumber = studentDto.RoleNumber,
                    Dob = studentDto.Dob,
                    Email = studentDto.Email,
                    City = studentDto.City,
                    State = studentDto.State,
                    Address = studentDto.Address,
                    gender = gender,
                    DepartmentId = studentDto.DepartmentId
                };

                if (!student.Email.Contains("@"))
                {
                    return BadRequest("Entered value '" + student.Email + "' is not in Correct Formate");
                }
                var s = IStudentRepository.UpdateStudent(student);
                return Ok("Updated Successfully");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Try Again");
            }
        }

        // DELETE END POINT
        [HttpDelete]
        [Route("Delete")]
        public ActionResult DeleteStudent(int Id)
        {
            try
            {
                return Ok(IStudentRepository.DeleteStudent(Id));
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Try Again");
            }
        }

    }
}
