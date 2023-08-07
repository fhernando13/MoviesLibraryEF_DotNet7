
namespace movieLibrary.Entities
{
    public class User
    {
        public int Iduser { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;        
    }
}