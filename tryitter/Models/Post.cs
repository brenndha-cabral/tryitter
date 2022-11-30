using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string? Content { get; set; }
        public DateTime Release { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
    }
}