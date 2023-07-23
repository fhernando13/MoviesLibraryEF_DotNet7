
namespace movieLibrary.Entities
{
    public class Comment
    {
        public  int Idcomment { get; set; }
        public string? Comments { get; set; }
        public bool Recommend { get; set; }
        public int Movieid { get; set; }
        public Movie Movie { get; set; } = null!;
        
    }
}