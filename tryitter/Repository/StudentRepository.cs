using Microsoft.EntityFrameworkCore;
using tryitter.Database;
using tryitter.DTO;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Repository
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly AplicationContext _context;

        public StudentRepository(AplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentNameDTO>> GetStudents()
        {
            var students = await _context.Students
                .Select(s => new StudentNameDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name
                }).ToListAsync();

            return students;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsWithPosts()
        {
            var students = await _context.Students
                .Select(s => new StudentDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Age= s.Age,
                    Birthday= s.Birthday,
                    Email= s.Email,
                    Gender= s.Gender,
                    Posts = s.Posts.Select(b => new PostDTO
                    {
                        PostId = b.PostId,
                        Content= b.Content,
                        Comments= b.Comments,
                        Likes= b.Likes,
                        Published= b.Published,
                    }).ToList()
                }).ToListAsync();

            return students;
        }

        public async Task<StudentNameDTO> GetStudentById(int id)
        {
            var student = await _context.Students.Where(s => s.StudentId == id)
                .Select(s => new StudentNameDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name
                }).FirstOrDefaultAsync();

            return student;
        }

        public async Task<StudentDTO> GetStudentByIdWithPost(int id)
        {

            var student = await _context.Students
                .Where(x => x.StudentId == id)
                .Select(s => new StudentDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Age = s.Age,
                    Birthday = s.Birthday,
                    Email = s.Email,
                    Gender = s.Gender,
                    Posts = s.Posts.Select(b => new PostDTO
                    {
                        PostId = b.PostId,
                        Content = b.Content,
                        Comments = b.Comments,
                        Likes = b.Likes,
                        Published = b.Published,
                    }).ToList()
                }).FirstOrDefaultAsync();

            return student;
        }

        public async Task<StudentNameDTO> GetStudentByName(string name)
        {
            var student = await _context.Students.Where(s => s.Name == name)
                .Select(s => new StudentNameDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name
                }).FirstOrDefaultAsync();

            return student;
        }

        public async Task<string> GetStudentByEmail(string email)
        {
            var student = await _context.Students.Where(s => s.Email == email)
                .Select(s => s.Email).FirstOrDefaultAsync();

            return student;
        }
        public async Task<StudentNameDTO> CreateStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            _context.SaveChanges();

            return new StudentNameDTO
            {
                Name = student.Name
            };
        }

        public async Task<StudentNameDTO> UpdateStudent(Student newStudent, int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);

            student.Name = newStudent.Name;
            _context.SaveChanges();

            return new StudentNameDTO
            {
                Name = newStudent.Name
            };
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
