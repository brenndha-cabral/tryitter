using System.ComponentModel.DataAnnotations.Schema;
using tryitter.Models;

namespace tryitter.DTO
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string? Content { get; set; }
        public string Published { get; set; }
        public int Likes { get; set; }
        public string? Comments { get; set; }
        public int StudentId { get; set; }
    }
}
