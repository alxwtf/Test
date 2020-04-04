namespace Backend.Model
{
    public class UserMoviesList
    {
        public int id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Lst List { get; set; }
    }

    public enum Lst
    {
        InProgress = 1,
        InPlans = 2,
        Done = 3
    }
}