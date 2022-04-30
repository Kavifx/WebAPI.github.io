using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.RepoImpl;
using WebAPI.RepoInterfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CrossAccess")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepo departmentRepo;
        public DepartmentController(IDepartmentRepo repo)
        {
            departmentRepo = repo;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FetchById(int id)
        {
            var dept = departmentRepo.GetById(id);
            return Ok(dept);
        }

        [HttpGet]
        public IActionResult FetchAll()
        {
            var dept = departmentRepo.GetAll();
            return Ok(dept);
        }        

        [HttpPost]
        public IActionResult AddDept(DepartmentDTO dept)
        {
            bool Added = departmentRepo.AddDept(dept);
            if(Added)
            {
                return Created(nameof(AddDept), "Success in updating Department : " + dept.DepartmentName);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPut]
        public IActionResult UpdateDept(DepartmentDTO dept)
        {
            bool Updated = departmentRepo.UpdateDept(dept);
            if (Updated)
            {
                return Ok("Department Updated");
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteDept(int id)
        {
            bool deleted = departmentRepo.DeleteDept(id);
            if (deleted)
            {
                return Ok("Department Deleted");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
