
namespace movieLibrary.DTO
{
    public class MovieCreateDto
    {
        public string Title { get; set; } = null!;
        public  bool Oncinema { get; set; }
        public DateTime Daterelease { get; set; }
        public List<int> Genders { get; set; }  = new List<int>();
        public List<MovieActorCreateDto> MovieActors { get; set; } 
                = new List<MovieActorCreateDto>();
    }
}