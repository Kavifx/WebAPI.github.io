using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.RepoInterfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    [EnableCors("CrossAccess")]
    public class StudentController : ControllerBase
    {
        private IStudentRepo studentRepo;
        public StudentController(IStudentRepo repo)
        {
            studentRepo = repo;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FecthById(int id)
        {
            var student = studentRepo.GetById(id);
            return Ok(student);
        }

        [HttpGet]
        public IActionResult FetchAll()
        {
            var student = studentRepo.GetAll();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDTO student)
        {
            bool Added = studentRepo.AddStudent(student);
            if (Added)
            {
                return Created(nameof(AddStudent), "Success in updating Student : " + student.StudentName);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPut]
        public IActionResult UpdateStudent(StudentDTO student)
        {
            bool Updated = studentRepo.UpdateStudent(student);
            if (Updated)
            {
                return Ok("Student Updated");
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete]        
        public IActionResult DeleteStudent(int id)
        {
            bool Deleted = studentRepo.DeleteStudent(id);
            if (Deleted)
            {
                return Ok("Student Deleted");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
