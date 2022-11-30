using tryitter.DTO;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<StudentDTO> GetStudents();
        StudentDTO GetStudentById(int id);
        StudentNameDTO CreateStudent(Student post);
        StudentNameDTO UpdateStudent(Student post, int studentId);
        void DeleteStudent(int id);
    }
}
