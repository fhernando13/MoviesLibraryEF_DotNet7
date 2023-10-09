
namespace movieLibrary.Entities
{
    public class User
    {
        public int Iduser { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthdate { get; set; }        
        public string? Role { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }   
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }           
    }    
}