
namespace movieLibrary.Entities
{
    public class MovieActor
    {
        public int Movieid { get; set; }
        public Movie Movie{ get; set; } = null!;
        public int Actorid { get; set; }
        public Actor Actor{ get; set; } = null!;
        public string Character { get; set; } = null!;
        public int Order { get; set; }
    }
}