
namespace movieLibrary.Entities
{
    public class Gender
    {           
        public int Idgender { get; set; }
        public string Name { get; set; } = null!;
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}