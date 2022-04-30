
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
    public class SemesterController : ControllerBase
    {
        private ISemesterRepo semesterRepo;
        public SemesterController(ISemesterRepo sem)
        {
            semesterRepo = sem;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FetchById(int id)
        {
            var sem = semesterRepo.GetById(id);
            return Ok(sem);
        }

        [HttpGet]
        public IActionResult FetchAll()
        {
            var semester = semesterRepo.GetAll();
            return Ok(semester);
        }

        [HttpPost]
        public IActionResult AddSemester(SemesterDTO sems)
        {
            bool Added = semesterRepo.AddSemester(sems);
            if (Added)
            {
                return Created(nameof(AddSemester), "Success in updating Semester : " + sems.SemesterName);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPut]
        public IActionResult UpdateSemester(SemesterDTO sems)
        {
            bool updated = semesterRepo.UpdateSemester(sems);
            if (updated)
            {
                return Ok("Semester is Updated");
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteSemester(int id)
        {
            bool deleted = semesterRepo.DeleteSemester(id);
            if (deleted)
            {
                return Ok("Semester is Deleted");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
