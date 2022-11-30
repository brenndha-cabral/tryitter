using tryitter.DTO;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<StudentNameDTO> GetStudents();
        StudentNameDTO GetStudentById(int id);
        StudentNameDTO GetStudentByName(string name);
        StudentNameDTO CreateStudent(Student post);
        StudentNameDTO UpdateStudent(Student post, int studentId);
        void DeleteStudent(int id);
    }
}
