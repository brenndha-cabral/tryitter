using System.ComponentModel.DataAnnotations.Schema;
using tryitter.Models;

namespace tryitter.DTO
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string? Content { get; set; }
        public DateTime Release { get; set; }
        public string? StudentName { get; set; }
    }

    public class PostInsert
    {
        public string? Content { get; set; }
        public string? StudentName { get; set; }
    }
}
