
namespace movieLibrary.Entities
{
    public class Movie
    {
        public int Idmovie { get; set; }
        public string Title { get; set; } = null!;
        public  bool Oncinema { get; set; }
        public DateTime Daterelease { get; set; }
        public HashSet<Comment> Commentss { get; set; } = new HashSet<Comment>();
        public HashSet<Gender> Genders { get; set; } = new HashSet<Gender>();
        public List<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}