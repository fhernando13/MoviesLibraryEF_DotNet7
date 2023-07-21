
namespace movieLibrary.Entities
{
    public class Comment
    {
        public  int Id_comment { get; set; }
        public string? Comments { get; set; }
        public bool Recommend { get; set; }
        public int Movie_ID { get; set; }
        public Movie Movie { get; set; } = null!;
        
    }
}