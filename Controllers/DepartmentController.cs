using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Dto;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Controllers
{
    [Route("Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepository IDepartmentRepository;
        public DepartmentController(IDepartmentRepository IDepartmentRepository)
        {
            this.IDepartmentRepository = IDepartmentRepository;
        }

        //CREATE ENDPOINT
        [HttpPost]
        [Route("Create")]
        public ActionResult CreateDepartment(DepartmentDto departmentDto)
        {
            try
            {
                Department department = new Department
                {
                    Id = departmentDto.Id,
                    Name = departmentDto.Name,
                    HodName = departmentDto.HodName
                };

                var r = IDepartmentRepository.AddDepartment(department);
                return Ok(r);

            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return StatusCode(500," Id " + departmentDto.Id + " is already Taken!");
            }
            catch (System.Exception)
            {
                
                return StatusCode(500,"Try again with Vaild Data");
            }

        }

        //GET BY ID ENDPOINT
        [HttpGet]
        [Route("GetById")]
        public ActionResult<DepartmentDto> GetById(int Id)
        {
            try
            {
                Department d = IDepartmentRepository.GetDepartmentById(Id);
                DepartmentDto department = new DepartmentDto { 
                 Id = d.Id,
                 Name = d.Name,
                 HodName = d.HodName
                };
                return Ok(department);
            }
            catch (System.InvalidOperationException)
            {
                return NotFound("Department with Id " + Id + " Not Found");
            }
            catch (System.Exception)
            {
               
                return StatusCode(500, "Try again with Vaild Data");
            }
        }

        //UPDATE ENDPOINT   
        [HttpPut]
        [Route("Update")]
        public ActionResult UpdateDepartment(DepartmentDto departmentDto)
        {
            try
            {
                Department department = new Department
                {
                    Id = departmentDto.Id,
                    Name = departmentDto.Name,
                    HodName = departmentDto.HodName
                };
                var d = IDepartmentRepository.UpdateDepartment(department);
                return Ok(d);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "try again with Valid Data");
            }
        }

        //GET ALL DEPARTMENT
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<DepartmentDto>> GetAllDepartment()
        {
            try
            {
                var d = IDepartmentRepository.GetAllDepartment();
                if (d != null) return Ok(IDepartmentRepository.GetAllDepartment());
                else return NotFound();
            }
            catch (System.NullReferenceException)
            {
                return NotFound("Empty");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "try again");
            }
        }

        //DELETE END POINT
        [HttpDelete]
        [Route("Delete")]
        public ActionResult DeleteDepartment(int Id)
        {
            try
            {
                return Ok(IDepartmentRepository.DeleteDepartment(Id));
            }
            catch (System.NullReferenceException)
            {
                return NotFound("Department with Id " + Id + " Not Found");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "try again");
            }
        }
    }
}
