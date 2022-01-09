using System.ComponentModel.DataAnnotations;

namespace DoggyCare.DTOs
{
    public record UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}