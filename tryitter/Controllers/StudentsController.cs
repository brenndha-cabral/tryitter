using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

            //Assim consigo ver se esse array anulável está nulo ou vazio, se fosse para verificar se estivesse apenas vazio, seria !students.Any()
            if (!(students?.Any() == true)) 
            {
                return NotFound("Students not fount");
            }

            return Ok(students);
        }

    }
}