

namespace movieLibrary.Entities
{
    public class Actor
    {
        public int Id_actor { get; set; }
        public string Name { get; set; } = null!;
        public decimal Fortune { get; set; }
        public DateTime Birthdate { get; set; }
        public List<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}