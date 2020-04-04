namespace Backend.Model
{
    public class Review
    {
        public int id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Text{get;set;}
    }
}