using Microsoft.AspNetCore.Mvc;
using tryitter.Interfaces;

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

            if (students is null)
            {
                return NotFound("Students not fount");
            }

            return Ok(students);
        }

    }
}