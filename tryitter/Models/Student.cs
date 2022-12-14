using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models
{
    public class Student
    {
        [Key]
        [JsonIgnore]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        public string? Birthday { get; set; } = null;

        [Required(ErrorMessage = "Gender is required.")]
        public string? Gender { get; set; } = null;

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(
            @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Email in invalid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(
            255,
            MinimumLength = 5,
            ErrorMessage =
            "The Password must be between 5 and 255 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [JsonIgnore]
        public ICollection<Post>? Posts { get; set; }
    }
}
