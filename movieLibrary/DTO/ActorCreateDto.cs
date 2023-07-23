using System.ComponentModel.DataAnnotations;

namespace movieLibrary.DTO
{
    public class ActorCreateDto
    {
        public int Idactor { get; set; }
        public string Name { get; set; } = null!;
        public decimal Fortune { get; set; }
        public DateTime Birthdate { get; set; }
    }
}