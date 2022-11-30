using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
