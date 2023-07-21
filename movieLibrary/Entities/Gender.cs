
namespace movieLibrary.Entities
{
    public class Gender
    {           
        public int Id_gender { get; set; }
        public string Name { get; set; } = null!;
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}