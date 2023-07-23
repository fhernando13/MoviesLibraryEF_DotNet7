using System.ComponentModel.DataAnnotations;

namespace movieLibrary.DTO
{
    public class GenderCreateDto
    {   
        [StringLength(maximumLength: 100)]
        public string Name { get; set; } = null!;
    }
}