using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tryitter.Models
{
    public class Post
    {
        [Key]
        [JsonIgnore]
        public int PostId { get; set; }

        [StringLength(
            300,
            ErrorMessage = "The post must have a maximum of 300 characters")]
        public string? Content { get; set; }

        [JsonIgnore]
        public string Published { get; set; } = DateTime.Now.ToString();

        [JsonIgnore]
        public int Likes { get; set; }

        [JsonIgnore]
        [StringLength(
            100,
            ErrorMessage = "The comment must have a maximum of 100 characters")]
        public string? Comments { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}