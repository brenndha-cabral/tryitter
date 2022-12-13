using tryitter.DTO;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentNameDTO>> GetStudents();
        Task<IEnumerable<StudentDTO>> GetStudentsWithPosts();
        Task <StudentDTO> GetStudentByIdWithPost(int id);
        Task<StudentNameDTO> GetStudentById(int id);
        Task<StudentNameDTO> GetStudentByName(string name);
        Task<string> GetStudentByEmail(string email);
        Task <StudentNameDTO> CreateStudent(Student student);
        Task <StudentNameDTO> UpdateStudent(Student student, int studentId);
        void DeleteStudent(int id);
    }
}
