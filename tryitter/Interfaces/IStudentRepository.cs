using tryitter.DTO;

namespace tryitter.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<StudentDTO> GetStudents();
        StudentDTO GetStudentById(int id);
        StudentDTO CreateStudent(StudentNameDTO post);
        StudentDTO UpdateStudent(StudentNameDTO post, int postId);
        void DeleteStudent(int id);
    }
}
