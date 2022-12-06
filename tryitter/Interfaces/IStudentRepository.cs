using tryitter.DTO;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentNameDTO>> GetStudents();
        Task <StudentNameDTO> GetStudentById(int id);
        Task<StudentNameDTO> GetStudentByName(string name);
        Task <StudentNameDTO> CreateStudent(Student student);
        Task <StudentNameDTO> UpdateStudent(Student student, int studentId);
        void DeleteStudent(int id);
    }
}
