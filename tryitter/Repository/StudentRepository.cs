using tryitter.Database;
using tryitter.DTO;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Repository
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            return _context.Students
                .Select(s => new StudentDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Posts = s.Posts!.Select(p => new PostDTO
                    {
                        Content = p.Content,
                        Release = p.Release,
                        PostId= p.PostId,
                        StudentName = s.Name
                    }).ToList()
                });
        }

        public StudentDTO GetStudentById(int id)
        {
            return _context.Students.Where(s => s.StudentId == id)
                .Select(s => new StudentDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Posts = s.Posts!.Select(p => new PostDTO
                    {
                        Content = p.Content,
                        Release = p.Release,
                        PostId = p.PostId,
                        StudentName = s.Name
                    }).ToList()
                }).First();
        }

        public StudentNameDTO CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return new StudentNameDTO
            {
                Name = student.Name

            };
        }

        public StudentNameDTO UpdateStudent(Student newStudent, int studentId)
        {
            var student = _context.Students.Find(studentId);

            if (student is null)
            {
                throw new Exception("Student not found");
            }

            student.Name = newStudent.Name;
            _context.SaveChanges();

            return new StudentNameDTO { Name = newStudent.Name };
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);

            if (student is null)
            {
                throw new Exception("Student not found");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
