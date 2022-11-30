using tryitter.Database;
using tryitter.DTO;
using tryitter.Interfaces;

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
            var teste = _context.Students
                .Select(s => new StudentDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Posts = s.Posts.Select(p => new PostDTO
                    {
                        Content = p.Content,
                        Release = p.Release,
                        PostId= p.PostId,
                        StudentName = s.Name
                    }).ToList()
                });
        }

    }
}
