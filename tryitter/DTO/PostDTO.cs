using System.ComponentModel.DataAnnotations.Schema;
using tryitter.Models;

namespace tryitter.DTO
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string? Content { get; set; }
        public DateTime Release { get; set; }
        public int StudentId { get; set; }
    }

    public class PostInsert
    {
        public string? Content { get; set; }
        public int StudentId { get; set; }
    }
}
