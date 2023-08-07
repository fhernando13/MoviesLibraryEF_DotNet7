using System.ComponentModel.DataAnnotations;

namespace movieLibrary.DTO
{
    public class UserLoginCreateDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}