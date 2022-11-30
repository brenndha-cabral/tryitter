using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentRepository.GetStudents();

            //Assim consigo ver se esse array anulável está nulo ou vazio, se fosse para verificar se estivesse apenas vazio, seria !students.Any()
            if (!(students?.Any() == true))
            {
                return NotFound("Students not fount");
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            if (student is null)
            {
                return NotFound("Student not fount");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            var studentByName = _studentRepository.GetStudentByName(student.Name);

            if (studentByName is not null)
            {
                return NotFound("Student already exist");
            }

            var newStudent = _studentRepository.CreateStudent(student);

            return Created("", $"{newStudent.Name} registered successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] Student student, int id)
        {
            var studentById = _studentRepository.GetStudentById(id);

            if (studentById is null)
            {
                return NotFound("Student not fount");
            }

            var updateStudent = _studentRepository.UpdateStudent(student, id);

            return Ok($"{updateStudent.Name} successfully updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentById = _studentRepository.GetStudentById(id);

            if (studentById is null)
            {
                return NotFound("Student not fount");
            }

            _studentRepository.DeleteStudent(id);

            return NoContent();
        }
    }
}