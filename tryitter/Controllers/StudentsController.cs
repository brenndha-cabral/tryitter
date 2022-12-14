using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudents();

            if (!(students?.Any() == true))
            {
                return NotFound("Students not fount");
            }

            return Ok(students);
        }

        [Authorize]
        [HttpGet("posts")]
        public async Task<IActionResult> GetStudentsWithPosts()
        {
            var students = await _studentRepository.GetStudentsWithPosts();

            //Assim consigo ver se esse array anulável está nulo ou vazio, se fosse para verificar se estivesse apenas vazio, seria !students.Any()
            if (!(students?.Any() == true))
            {
                return NotFound("Students not fount");
            }

            return Ok(students);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);

            if (student is null)
            {
                return NotFound("Student not fount");
            }

            return Ok(student);
        }

        [Authorize]
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetStudentByIdWithPost(int id)
        {
            var student = await _studentRepository.GetStudentByIdWithPost(id);

            if (student is null)
            {
                return NotFound("Student not fount");
            }

            return Ok(student);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            var studentByName = await _studentRepository.GetStudentByName(student.Name);

            if (studentByName is not null)
            {
                return NotFound("Student already exist");
            }

            var newStudent = await _studentRepository.CreateStudent(student);

            return Created("", $"{newStudent.Name} registered successfully!");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student, int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var getClaim = identity.FindFirst("Id").Value;

            if (Convert.ToInt32(getClaim) != id)
            {
                return Unauthorized("Student logged in does not match the one sought for updating. Unable to update.");
            }

            var studentById = await _studentRepository.GetStudentById(id);

            if (studentById is null)
            {
                return NotFound("Student not fount");
            }

            var updateStudent = await _studentRepository.UpdateStudent(student, id);

            return Ok($"{updateStudent.Name} successfully updated!");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var getClaim = identity.FindFirst("Id").Value;

            if (Convert.ToInt32(getClaim) != id)
            {
                return Unauthorized("Student logged in does not match the one sought for removal. Unable to remove.");
            }

            var studentById = await _studentRepository.GetStudentById(id);

            if (studentById is null)
            {
                return NotFound("Student not fount");
            }

            _studentRepository.DeleteStudent(id);

            return NoContent();
        }
    }
}