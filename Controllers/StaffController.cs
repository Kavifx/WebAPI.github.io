using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.RepoImpl;
using WebAPI.RepoInterfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CrossAccess")]
    public class StaffController : ControllerBase
    {
        IStaffRepo staffRepo;
        public StaffController(IStaffRepo repo)
        {
            staffRepo = repo;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FetchById(int id)
        {
            var staff = staffRepo.GetById(id);
            return Ok(staff);
        }

        [HttpGet]
        public IActionResult FetchAll()
        {
            var staff = staffRepo.GetAll();
            return Ok(staff);
        }

        [HttpPost]
        public IActionResult AddStaff(StaffDTO staff)
        {
            bool Added = staffRepo.AddStaff(staff);
            if (Added)
            {
                return Created(nameof(AddStaff), "Success in updating Department : " + staff.StaffName);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPut]
        public IActionResult UpdateStaff(StaffDTO staff)
        {
            bool Updated = staffRepo.UpdateStaff(staff);
            if (Updated)
            {
                return Ok("Staff Updated");
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            bool deleted = staffRepo.DeleteStaff(id);
            if (deleted)
            {
                return Ok("Staff Deleted");
            }
            else
            {
                return BadRequest("Error");
            }
        }

    }
}
