using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [StringLength(
            300,
            ErrorMessage = "The post must have a maximum of 300 characters")]
        public string? Content { get; set; }

        public string Published { get; set; } = DateTime.Now.ToString();
        public int Likes { get; set; }

        [StringLength(
            100,
            ErrorMessage = "The comment must have a maximum of 100 characters")]
        public string? Comments { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}