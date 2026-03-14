using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UMS.DTO;
using UMS.Services;
using NLog;

namespace UMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService service, ILogger<StudentController> logger)
        {
            _service = service;
            _logger = logger;
        }
       

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(StudentHostelDTO dto)
        {
            await _service.CreateStudent(dto);

            return Ok("Student Created");
        }

        [HttpPut("update-room")]
        [Authorize]
        public async Task<IActionResult> UpdateRoom(int studentId, int roomNo)
        {
            await _service.UpdateRoom(studentId, roomNo);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteStudent(id);
            return Ok();
        }

        [HttpGet("hostel-students")]
        [Authorize]
        public async Task<IActionResult> HostelStudents()
        {
            return Ok(await _service.GetStudentsInHostel());
        }

        [HttpGet("all-students")]
        [Authorize]
        public async Task<IActionResult> AllStudents()
        {
            var res = await _service.GetAllStudents();
            if (res != null)
                _logger.LogInformation("Students Data is Fetched Successfully!",res);
            return Ok(res);
        }
    }
    
}