using tryitter.Models;

namespace tryitter.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Birthday { get; set; }
        public string Email { get; set; }
        public string? Gender { get; set; }
        public string Password { get; set; }
        public ICollection<PostDTO>? Posts { get; set; }
    }

    public class StudentNameDTO
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
    }
}
