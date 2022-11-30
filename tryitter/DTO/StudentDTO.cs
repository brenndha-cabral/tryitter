using tryitter.Models;

namespace tryitter.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public ICollection<PostDTO>? Posts { get; set; }
    }

    public class StudentNameDTO
    {
        public string? Name { get; set; }
    }
}
