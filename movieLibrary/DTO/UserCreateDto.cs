using System.ComponentModel.DataAnnotations;

namespace movieLibrary.DTO
{
    public class UserCreateDto
    {
        public int Iduser { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthdate { get; set; }        
        public string? Role { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? Token { get; set; }   
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }  
    }
}