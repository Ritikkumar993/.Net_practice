using CollegePortalApi.DTO;
using CollegePortalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegePortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        // POST: api/student
        [HttpPost]
        public IActionResult CreateStudent(StudentCreateDTO request)
        {
            Student student = new Student
            {
                Id = students.Count + 1,
                Name = request.Name,
                Age = request.Age,
             
            };

            students.Add(student);

            return Ok(student.Id);
        }

        // GET: api/student
        [HttpGet]
        public ActionResult<List<StudentReportDTO>> GetStudents()
        {
            var result = students.Select(s => new StudentReportDTO
            {
                Id = s.Id,
                Name = s.Name,
                M1= s.M1,
                M2= s.M2,
                Total = s.Total,
                Grade = s.Grade

            }).ToList();

            return Ok(result);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public ActionResult<StudentReportDTO> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            var result = new StudentReportDTO
            {
                Id = student.Id,
                Name = student.Name,
                M1 = student.M1,
                M2 = student.M2,
                Total = student.Total,
                Grade = student.Grade
            };

            return Ok(result);
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDTO request)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            student.M1 = request.M1;
            student.M2 = request.M2;
            student.Total = request.M1 + request.M2;

            int percent = (request.M1 + request.M2) / 2;
            string grade = "";
            if (percent > 90) grade = "O";
            else if (percent > 80) grade = "A+";
            else if (percent > 70) grade = "A";
            else if (percent > 60) grade = "B+";
            else if (percent > 50) grade = "B";
            else if (percent > 40) grade = "C";
            else if (percent > 30) grade = "D";
            else grade = "F";

            student.Grade = grade;

            return Ok();
        }
    }
}
